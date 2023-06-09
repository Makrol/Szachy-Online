import React, { useEffect, useRef, useState } from "react"
import InvHub, { GameService ,ChessHub } from "../services/GameServices";
import Swal from "sweetalert2";
import { useNavigate } from "react-router-dom";
import winnerIcon from "../img/winner.png";
export default function GameController({children,getOpenings,getUserById})
{
    const game = useRef(null);
    const invHubInstance =  new InvHub();
    const chessHub = new ChessHub();
    const gameGateway = new GameService();
    const navigate = useNavigate();
    
    const [receiveMoveAlert,setReceiveMoveAlert] = useState(true);

    const [lastEnemyMove,setLastEnemyMove] = useState();
    const receiveInvate = (senderUid,color) =>{
        if(senderUid==="Cancel Invitation")
        {
            debugger
           if(InvHub.blockFun!==null)
            {
                InvHub.blockFun(false)
            }
            Swal.fire({
                position: 'center',
                icon: 'error',
                title: 'Użytkownik odrzucił zaproszenie',
                background: "#20201E",
                showConfirmButton: true,
              });
        }
        else if(senderUid === "Friend not responded")
        {
            Swal.fire({
                position: 'center',
                icon: 'error',
                title: 'Użytkownik nie przyjął zaproszenia',
                background: "#20201E",
                showConfirmButton: true,
              });
        }
        else{

            InvHub.senderUid = senderUid;
            InvHub.senderColor = color;
            console.log(color);
            InvHub.openInvate();
        }
       
    }
    const invateToGame = (receiverUid) =>{
        invHubInstance.sendInvate(receiverUid);
    }
    const cancelInvate = (receiverUid) =>{
        invHubInstance.cancelGameInvate(receiverUid)
    }
    const timeOutInvate = (receiverUid) =>{
        invHubInstance.timeOutInvate(receiverUid);
    }
    const setInvateDialogRef = (open,close) =>{
 
        console.log("ustawiam");
        InvHub.openInvate = open;
       // setHandleCloseInvate(close);
        //setHandleOPenInvate(open);
    }

    const onReceiveStartGame = (gameId) =>{
        debugger
        localStorage.gameId = gameId;
        console.log(gameId);
        setChessHubOnGame()
        navigate("/chessBoard")
        
    }

    const onReceivePlayerMove = (move) =>{
        if(move === "Winner")
        {
            var imageElement = document.createElement('img');
            imageElement.src = winnerIcon;
            imageElement.style.width = '100%';
            imageElement.style.height = '90%';
            Swal.fire({
                position: 'center',
                color:'white',
                html: imageElement.outerHTML+('<p>Przeciwnik poddał gre</p>'),
                background: "#20201E",
                showConfirmButton: true,
                allowOutsideClick: false
              }).then(()=>navigate("/home"))
            
        }
        else{
            console.log("odbieram: "+move);
            setLastEnemyMove(move);
            setReceiveMoveAlert(!receiveMoveAlert);
        }
        
       
    }


    const createGameOnlineWithPlayer = async(guid,color) =>{
        const response = await gameGateway.createGameOnlineWithPlayer(guid,color);

        if(response.status === 200)
        {
            console.log(response);
        }else{
            Swal.fire({
                position: 'center',
                icon: 'error',
                title: 'Błąd tworzenia nowej rozgrywki',
                background: "#20201E",
                showConfirmButton: false,
                timer: 1500
              });
            return null;
        }
    }
    const createGameWithComputer = async(level,color,openingId) =>{
        const response = await gameGateway.createGameWithComputer(level,color,openingId);
        if(response.status === 200)
        {
            localStorage.gameIdComputer = response.data.gameID;
            localStorage.pgnComputer = response.data.pgn;
            navigate("/chessBoardComputer",{state:{color:color}});
        }else{
            Swal.fire({
                position: 'center',
                icon: 'error',
                title: 'Błąd tworzenia rozgrywki z komputerem',
                background: "#20201E",
                showConfirmButton: false,
                timer: 1500
              });
            return null;
        }
    }

    const startGameWithComputer = async(gameId) =>{
        const response = await gameGateway.startGameWithComputer(gameId);
        if(response.status === 200)
        {
            console.log(response);
        }else{
            Swal.fire({
                position: 'center',
                icon: 'error',
                title: 'Błąd rozpoczęcia rozgrywki z komputerem',
                background: "#20201E",
                showConfirmButton: false,
                timer: 1500
              });
            return null;
        }

    }

    const sendPlayerMove = async(move)=>{
        
        
        const response = await gameGateway.playerMove(move);

        if(response.status === 200)
        {
            
            return response.data;
        }
        else{
            //console.log(response);
        }
        
    }    
    const sendPlayerMoveComputer = async(move)=>{
        
        
        const response = await gameGateway.computerMove(move);

        if(response.status === 200)
        {
            
            return response.data;
        }
        else{
            //console.log(response);
        }
        
    }    
    const getInfoAboutGame = async(gameId) =>{
        const response = await gameGateway.getInfoAboutGame(gameId);

        if(response.status === 200)
        {
            
            return response.data;
        }
        else{
            //console.log(response);
        }
    }

    const getPlayerMove = async()=>{
        return "c6";
    }
    const setChessHubOnReceive = async()=>{
        if(ChessHub.onReceiveGameData !== onReceiveStartGame)
        {
            ChessHub.onReceiveGameData = onReceiveStartGame;
            chessHub.refactorConnection();
        }
    }
    const setChessHubOnGame = async()=>{

        if(ChessHub.onReceiveGameData !== onReceivePlayerMove)
        {
            ChessHub.onReceiveGameData = onReceivePlayerMove;
            await chessHub.refactorConnection();
        }
    }

    const setRefToGame = async(gameRef)=>{
        game.current = gameRef;
    }
    const setWinner = async(gameID,result) =>{
        const response = await gameGateway.setWinner(gameID,result);
    }
    const setBlockRef = async(ref) =>{
        InvHub.blockFun=ref;
    }

    const forfeit = async(gameId)=>{
        const response = await gameGateway.forfeit(gameId);
        if(response.status === 200)
        {
            navigate("/home")
            return response.data;
        }
        else{
            Swal.fire({
                position: 'center',
                icon: 'error',
                title: 'Błąd procesu poddawania',
                background: "#20201E",
                showConfirmButton: true,
              });
        }
    }

    InvHub.onReceiveInvate = receiveInvate;
    //ChessHub.onReceiveGameData = onReceiveStartGame;
    return React.cloneElement(children,{
        invateToGame,
        setInvateDialogRef,
        createGameOnlineWithPlayer,
        createGameWithComputer,
        sendPlayerMove,
        setChessHubOnGame,
        setChessHubOnReceive,
        getPlayerMove,
        setRefToGame,
        getInfoAboutGame,
        receiveMoveAlert,
        lastEnemyMove,
        getOpenings,
        startGameWithComputer,
        sendPlayerMoveComputer,
        getUserById,
        cancelInvate,
        timeOutInvate,
        setWinner,
        setBlockRef,
        forfeit
    })

    
}