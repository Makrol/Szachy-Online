﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using szachy_online.Api.Data;
using szachy_online.Api.Dto;
using szachy_online.Api.Entities;

namespace szachy_online.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FriendsController : ControllerBase
    {
        private readonly DataContext _context;

        public FriendsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Friends
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FriendsEntity>>> GetFriends()
        {
            if (_context.Friends == null)
            {
                return NotFound();
            }
            return await _context.Friends.ToListAsync();
        }

        // GET: api/Friends/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FriendsEntity>> GetFriendsEntity(long id)
        {
            if (_context.Friends == null)
            {
                return NotFound();
            }
            var friendsEntity = await _context.Friends.FindAsync(id);

            if (friendsEntity == null)
            {
                return NotFound();
            }

            return friendsEntity;
        }


        [HttpGet("sendInvitation/{nickname}")]
        public async Task<IActionResult> SendInvitation(string nickname)
        {
            Guid userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            //Guid userId = Guid.Parse("0565D667-5484-4432-B761-B8558FF6DC37");
            AccountEntity receiverAccountEntity = await _context.Accounts.FirstOrDefaultAsync(x => x.Nickname == nickname);

            if (FriendshipExists(userId, receiverAccountEntity.Id)){
                return BadRequest();
            }

            FriendsEntity friendsEntity = new FriendsEntity
            {
                FriendshipID = 0,
                User1ID = userId,
                User2ID = receiverAccountEntity.Id
            };

            _context.Friends.Add(friendsEntity);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet("GetListOfPendingInvitations")]
        public async Task<ActionResult<IEnumerable<FriendshipInfoDto>>> GetListOfPendingInvitations()
        {
            if (_context.Friends == null)
            {
                return NotFound();
            }
            Guid userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            //Guid userId = Guid.Parse("0565D667-5484-4432-B761-B8558FF6DC37");

            var friendships = await _context.Friends
                .Where(x => (x.User2ID == userId && x.Status == StatusFriendship.Pending.ToString()))
                .Include(x => x.User1).Include(x => x.User2).Select(z => new FriendshipInfoDto
                {
                    FriendshipId = z.FriendshipID,
                    UserId1 = z.User1ID,
                    User1Name = z.User1.Name,
                    User1Surname = z.User1.Surname,
                    User1Nickname = z.User1.Nickname,
                    UserId2 = z.User2ID,
                    User2Name = z.User2.Name,
                    User2Surname = z.User2.Surname,
                    User2Nickname = z.User2.Nickname,
                    DateModified = z.DateModified,
                }).ToListAsync();

            return friendships;
        }

        [HttpGet("GetListOfMySentInvitations")]
        public async Task<ActionResult<IEnumerable<FriendshipInfoDto>>> GetListOfMySentInvitations()
        {
            if (_context.Friends == null)
            {
                return NotFound();
            }
            Guid userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            //Guid userId = Guid.Parse("0565D667-5484-4432-B761-B8558FF6DC37");

            var friendships = await _context.Friends
                .Where(x => (x.User1ID == userId && x.Status == StatusFriendship.Pending.ToString()))
                .Include(x => x.User1).Include(x => x.User2).Select(z => new FriendshipInfoDto
                {
                    FriendshipId = z.FriendshipID,
                    UserId1 = z.User1ID,
                    User1Name = z.User1.Name,
                    User1Surname = z.User1.Surname,
                    User1Nickname = z.User1.Nickname,
                    UserId2 = z.User2ID,
                    User2Name = z.User2.Name,
                    User2Surname = z.User2.Surname,
                    User2Nickname = z.User2.Nickname,
                    DateModified = z.DateModified,
                }).ToListAsync();

            return friendships;
        }

        [HttpGet("GetListOfFriends")]
        public async Task<ActionResult<IEnumerable<FriendshipInfoDto>>> GetListOfFriends()
        {
            if (_context.Friends == null)
            {
                return NotFound();
            }
            Guid userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));


            //Guid userId = Guid.Parse("26E9E04F-3E34-4FDA-8147-377B62B031A1");
            var friendships = await _context.Friends
                .Where(x => (x.User2ID == userId && x.Status == StatusFriendship.Accept.ToString()) ||
                (x.User1ID == userId && x.Status == StatusFriendship.Accept.ToString())).Include(x => x.User1).Include(x => x.User2).Select(z => new FriendshipInfoDto
                {
                    FriendshipId = z.FriendshipID,
                    UserId1 = z.User1ID,
                    User1Name = z.User1.Name,
                    User1Surname = z.User1.Surname,
                    User1Nickname = z.User1.Nickname,
                    UserId2 = z.User2ID,
                    User2Name = z.User2.Name,
                    User2Surname = z.User2.Surname,
                    User2Nickname = z.User2.Nickname,
                    DateModified = z.DateModified,
                }).ToListAsync();

            return friendships;      
        }

        [HttpGet("acceptInvitation/{id}")]
        public async Task<IActionResult> AcceptInvitation(long id)
        {
            if (_context.Friends == null)
            {
                return NotFound();
            }
            Guid userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            //Guid userId = Guid.Parse("0565D667-5484-4432-B761-B8558FF6DC37");
            FriendsEntity friendsEntity = await _context.Friends.FindAsync(id);

            if (friendsEntity == null)
            {
                return NotFound();
            }

            if (friendsEntity.User2ID != userId)
            {
                return Unauthorized();
            }

            friendsEntity.Status = StatusFriendship.Accept.ToString();
            friendsEntity.DateModified = DateTime.Now;

            _context.Friends.Update(friendsEntity);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE: api/Friends/5
        [HttpDelete("removeFriend/{id}")]
        public async Task<IActionResult> RemoveFriend(long id)
        {
            if (_context.Friends == null)
            {
                return NotFound();
            }
            var friendsEntity = await _context.Friends.FindAsync(id);
            if (friendsEntity == null)
            {
                return NotFound();
            }

            Guid userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            //Guid userId = Guid.Parse("0565D667-5484-4432-B761-B8558FF6DC37");

            if (friendsEntity.User1ID != userId)
            {
                if(friendsEntity.User2ID != userId)
                {
                    return Unauthorized();
                }
            }

            _context.Friends.Remove(friendsEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FriendshipExists(Guid senderId, Guid receiverId)
        {
            return (_context.Friends?.Any(e => (e.User1ID==senderId && e.User2ID == receiverId) || (e.User1ID == receiverId && e.User2ID == senderId))).GetValueOrDefault();
        }

        // PUT: api/Friends/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFriendsEntity(long id, FriendsEntity friendsEntity)
        {
            if (id != friendsEntity.FriendshipID)
            {
                return BadRequest();
            }

            _context.Entry(friendsEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FriendsEntityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Friends
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FriendsEntity>> PostFriendsEntity(FriendsEntity friendsEntity)
        {
          if (_context.Friends == null)
          {
              return Problem("Entity set 'DataContext.Friends'  is null.");
          }
            _context.Friends.Add(friendsEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFriendsEntity", new { id = friendsEntity.FriendshipID }, friendsEntity);
        }

        

        private bool FriendsEntityExists(long id)
        {
            return (_context.Friends?.Any(e => e.FriendshipID == id)).GetValueOrDefault();
        }
    }
}
