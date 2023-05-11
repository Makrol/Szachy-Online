import { useState } from "react";
import { ThemeInput } from "./ThemeInput";
import React from "react";
import Dialog from '@mui/material/Dialog';
import DialogActions from '@mui/material/DialogActions';
import DialogContent from '@mui/material/DialogContent';
import DialogContentText from '@mui/material/DialogContentText';
import DialogTitle from '@mui/material/DialogTitle';
import FriendController from "../controllers/FriendController";

function AddFriendButtons({handleClose,onSendInvitation,nickname}){
    const onClickSend = () => {
        //console.log(nickname.charCodeAt(0));
        onSendInvitation(nickname);
        handleClose()
    }
    return(
        <button onClick={() => onClickSend()}>Wyślij zaproszenie</button>
    )

}

export default function AddFriend({open,handleClose})
{
    const[nickname,setNickname] = useState("");
    return(
        <Dialog

                open={open}
                onClose={handleClose}
                maxWidth
            >
                <DialogTitle>
                {"Dodaj znajomego"}
                </DialogTitle>
                <DialogContent>
                <DialogContentText>
                    <div>
                        Podaj nickname użytkownika którego chcesz dodać do znajomych
                        <ThemeInput id="filled-basic" label="Login" variant="outlined" fullWidth value={nickname} onChange={(e) => setNickname(e.target.value)}/>
                    </div>
                    
                </DialogContentText>
                </DialogContent>
                <DialogActions>
                    <FriendController>
                        <AddFriendButtons handleClose={handleClose} nickname={nickname}/>
                    </FriendController>
                </DialogActions>
            </Dialog>
    )
}