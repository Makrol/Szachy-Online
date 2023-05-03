import '../styles/Home.css';
import '../App.css';
import pawn from '../img/pawn.png';
import king from '../img/king.png';
import queen from '../img/queen.png';
import bishop from '../img/bishop.png';
import horse from '../img/horse.png';
import rook from '../img/rook.png';
import imgLogo from '../img/logo.png';
import imgChess from '../img/chess.png';
import imgFile from '../img/file.png';
import imgFriends from '../img/friends.png';
import imgLogin from '../img/login.png';
import imgRegister from '../img/register.png';
import React, { useState } from "react";
import onlineHumanHuman from "../img/occ.png";
import onlineHumanComputer from "../img/ocm.png";
import localHumanHuman from "../img/tcc.png";
import continueIcon from "../img/right-arrow.png";
import chessHistory from "../img/chessHistory.png";
import addFriend from "../img/add.png";
import friendList from "../img/friend.png";
import { useNavigate } from "react-router-dom";
import {Login, getUser, logout,register} from "../services/AccountService";
import { useEffect } from 'react';
import { ThemeInput } from '../components/ThemeInput';
import helpIcon from "../img/help.png";
import Swal from 'sweetalert2';

function Home() {
    const[userName,setUserName] = useState("");
    const [isLogged, setIsLogged] = useState(false);
    useEffect(() => {
         if(localStorage.getItem("accessToken")!=null) 
         {
            setIsLogged(true);
            getUser(setUserName);
         }
    }, []);



    const [nameVal,setNameVal] = useState("");
    const [surnameVal,setSurnameVal] = useState("");
    const [emailVal,setEmailVal] = useState("");
    const [loginValReg,setLoginValReg] = useState("");
    const [passwordValReg,setPasswordValReg] = useState("");
    const navigate = useNavigate();
 
    const [getGameStyle, setGameStyle] = useState({width:"0rem"});
    const showGameOptions=() =>{
        setGameStyle({width:"25rem"});
        
    }
    const hideGameOptions=() =>{
        setGameStyle({width:"0rem"});
    }

    const [getFileStyle, setFileStyle] = useState({width:"0rem"});
    const showFileOptions=() =>{
        setFileStyle({width:"25rem"});

    }
    const hideFileOptions=() =>{
        setFileStyle({width:"0rem"});
    }

    const [getFriendStyle,setFriendStyle] = useState({width:"0rem"});
    const showFriendOptions=() =>{
        setFriendStyle({width:"25rem"});

    }
    const hideFriendOptions=() =>{
        setFriendStyle({width:"0rem"});
    }
    
    const [getLoginStyle,setLoginStyle] = useState({width:"0rem"});
    const showLogin=() =>{
        setLoginStyle({width:"25rem"});

    }
    const hideLogin=() =>{
        setLoginStyle({width:"0rem"});
    }
    const [getRegisterStyle,setRegisterStyle] = useState({width:"0rem"});
    const showRegister=() =>{
        setRegisterStyle({width:"25rem"});

    }
    const hideRegister=() =>{
        setRegisterStyle({width:"0rem"});
    }

    const showHumanHumanOptions=()=>{
        hideGameOptions();
        showHumanHuman();
    }

    const [getHumanHumanOptionsStyle,setHumanHumanOptionsStyle] = useState({width:"0rem"});
    const showHumanHuman=() =>{
        setHumanHumanOptionsStyle({width:"55rem"});
    }
    const hideHumanHuman=() =>{
        setHumanHumanOptionsStyle({width:"0rem"});
    }

    const hideAdditionalMenu=()=>{
        setHumanHumanOptionsStyle({width:"0rem"});
        setTurnBasedOptionsStyle({width:"0rem"});
    }
    const [getTurnBasedOptionsStyle,setTurnBasedOptionsStyle] = useState({width:"0rem"});
    const showTurnBasedMenu=() =>{
        setTurnBasedOptionsStyle({width:"100%"});
    }
    const hideTurnBasedMenu=() =>{
        setTurnBasedOptionsStyle({width:"0rem"});
    }
    const startGameHumanHumanOnline=()=>{
        navigate("/chessBoard");
    }
    ////////////////* Edit Login from inputs*////////////////////
    const onChangeLogin = e =>{
        setIsLoginError(false);
        setLoginHelperText("");
        setLoginVal(e.target.value);
        setLoginStstus(200);
    }
    const onChangePassword = e =>{
        setIsLoginError(false);
        setLoginHelperText("");
        setPasswordnVal(e.target.value);
        setLoginStstus(200);
    }
    ///////////////////////////////////////////////////////////////////

    ////////////////* Edit Register from inputs*/////////////////////////
    const resetRegError=()=>{
        setIsRegisterError(false);
        setRegisterHelperLogEmailText("");
        setRegisterHelperText("");
        setRegisterStstus(200);
    }
    const onChangeNameReg = e =>{
        setNameVal(e.target.value);
        resetRegError();
    }
    const onChangeSurnameReg = e =>{
        setSurnameVal(e.target.value);
        resetRegError();
    }
    const onChangeEmailReg = e =>{
        setEmailVal(e.target.value);
        resetRegError();
    }
    const onChangeLoginReg = e =>{
        setLoginValReg(e.target.value);
        resetRegError();
    }
    const onChangePasswordReg = e =>{
        setPasswordValReg(e.target.value);
        resetRegError();
    }

    //////////////////////////////////////////////////////////////////

    ////////////////* Login error message system*////////////////////
    const[isLoginError,setIsLoginError] = useState(false);
    const[loginStstus,setLoginStstus] = useState(-1);
    const[loginHelperText,setLoginHelperText] = useState("");
    useEffect(() => {
        if(loginStstus==401)
        {
            setIsLoginError(true);
            setLoginHelperText("Niepoprawne dane logowania");
        }
        setLoginStstus(-1);
   }, [loginStstus]);
   ///////////////////////////////////////////////////////////////////

   ///////////////* Register error message system*////////////////////
   const[isRegisterError,setIsRegisterError] = useState(false);
   const[registerStstus,setRegisterStstus] = useState(-1);
   const[registerHelperLogEmailText,setRegisterHelperLogEmailText] = useState("");
   const[registerHelperText,setRegisterHelperText] = useState("");
   useEffect(() => {
        if(registerStstus===500)
        {
            setIsRegisterError(true);
            setRegisterHelperLogEmailText("Konto o podanym loginie lub email już istnieje");
        }
        else if(registerStstus===400)
        {
            setIsRegisterError(true);
            setRegisterHelperLogEmailText("Pola nie mogą być puste");
            setRegisterHelperText("Pola nie mogą byc puste");
        }
        setRegisterStstus(-1);
    }, [registerStstus]);

    const onClickRegister=()=>{
        
        register("3fa85f64-5717-4562-b3fc-2c963f66afa6",nameVal,surnameVal,emailVal,loginValReg,passwordValReg,setRegisterStstus);
        setNameVal("");
        setSurnameVal("");
        setEmailVal("");
        setLoginValReg("");
        setPasswordValReg("");
    }
   ///////////////////////////////////////////////////////////////////

   /////////////////////////* Help window*////////////////////////////
    const showHelpWindow = () =>{
        Swal.fire({
            icon: 'question',
            background: "#20201E",
            color: "white",
            width: "50rem",
            html:"<div><div style='font-size:2rem; font-weight:800;'>Napisz do nas jeśli masz problem</div><div style='color:#C26833; font-weight:800;'>email: szachyonline@gmail.com</div></div>",
            showConfirmButton: false,
          })
    }

   ///////////////////////////////////////////////////////////////////
    const[loginVal,setLoginVal] = useState("");
    const[passwordVal,setPasswordnVal] = useState("");
    

  return (
    <div className="App">

        

      <nav className="app-nav">
            <div className="logo">
                <img className="img-logo" src={imgLogo} alt=""/>
            </div>
            
            <button className="nav-btn" onMouseOver={showGameOptions} onMouseOut={hideGameOptions} onClick={hideAdditionalMenu}>
                <img className="btn-img" src={imgChess} alt=""/>
                <p>Graj</p>
            </button>
            <button className="nav-btn" onMouseOver={showFileOptions} onMouseOut={hideFileOptions}  onClick={hideAdditionalMenu}>
                <img className="btn-img" src={imgFile} alt=""/>
                <p>Pliki</p>
            </button>
            


            
            {
               !isLogged?
               <div>
                    <button className="nav-btn" onMouseOver={showLogin} onMouseOut={hideLogin}  onClick={hideAdditionalMenu}>
                        <img className="btn-img" src={imgLogin} alt=""/>
                        <p>Logowanie</p>
                    </button>
                    <button className="nav-btn" onMouseOver={showRegister} onMouseOut={hideRegister}  onClick={hideAdditionalMenu}>
                        <img className="btn-img" src={imgRegister} alt=""/>
                        <p>Rejestracja</p>   
                    </button>
                </div>
                :
                <div>
                    <button className="nav-btn" onMouseOver={showFriendOptions} onMouseOut={hideFriendOptions} onClick={hideAdditionalMenu}>
                        <img className="btn-img" src={imgFriends} alt=""/>
                        <p>Znajomi</p>
                    </button>
                    <button className="nav-btn" onClick={()=>logout(setIsLogged,setUserName)}>
                        <img className="btn-img" src={imgLogin} alt=""/>
                        <p>Wyloguj</p>
                    </button>
                </div>
            }
            <button className="nav-btn" onClick={showHelpWindow}>
                <img className="btn-img" src={helpIcon} alt="" />
                <p>Pomoc</p>
            </button>
            {
                isLogged?
                    <div className='logedAs'>
                        <p>Zalogowano jako:</p> 
                        {userName}
                    </div>
                :
                    <div></div>
            }
      </nav>
      <div className='option' style={getGameStyle} onMouseOver={showGameOptions}  onMouseOut={hideGameOptions}>
            <button className='nav-btn' onClick={showHumanHumanOptions}>
                <img className="btn-img" src={onlineHumanHuman} alt=""/>
                <p className='slide-btn-text'>Online Człowiek - Człowiek</p>
            </button>
            <button className='nav-btn' onClick={showTurnBasedMenu}>
                <img className="btn-img" src={localHumanHuman} alt=""/>
                <p className='slide-btn-text'>Turowo Człowiek - Człowiek</p>
            </button>
            <button className='nav-btn' onClick={()=>console.log(localStorage.accessToken)}>
                <img className="btn-img" src={onlineHumanComputer} alt=""/>
                <p className='slide-btn-text'>Online Człowiek - Maszyna</p>
            </button>
      </div>
      <div className='option' style={getFileStyle} onMouseOver={showFileOptions}  onMouseOut={hideFileOptions}>
            <button className='nav-btn'>
                <img className="btn-img" src={continueIcon} alt=""/>
                <p className='slide-btn-text'>Wznów gre z pliku</p>
            </button>
            <button className='nav-btn'>
                <img className="btn-img" src={chessHistory} alt=""/>
                <p className='slide-btn-text'>Historia rozgrywki z pliku</p>
            </button>
      </div>
      {
        isLogged?
            <div className='option' style={getFriendStyle} onMouseOver={showFriendOptions}  onMouseOut={hideFriendOptions}>
            <button className='nav-btn'>
                <img className="btn-img" src={friendList} alt=""/>
                <p className='slide-btn-text'>Lista znajomych</p>
            </button>
            <button className='nav-btn'>
                <img className="btn-img" src={addFriend} alt=""/>
                <p className='slide-btn-text'>Dodaj znajomego</p>
            </button>
            </div>
        :
            <div></div>

      }
      
      {
        !isLogged?
            <div>
                <div className='option' style={getLoginStyle} onMouseOver={showLogin}  onMouseOut={hideLogin}>
                    <div className='option-elements'>
                        <ThemeInput error={isLoginError} helperText={loginHelperText} id="filled-basic" label="Login" variant="outlined" fullWidth value={loginVal} onChange={onChangeLogin}/>
                        <ThemeInput error={isLoginError} helperText={loginHelperText} id="filled-basic" label="Hasło" variant="outlined" fullWidth value={passwordVal} onChange={onChangePassword} type="password"/>
                        <button className='option-btn' onClick={()=>Login(loginVal,passwordVal,setIsLogged,setLoginStstus,setUserName)}>
                            <p className='slide-btn-text'>Zaloguj</p>
                        </button>
                    </div>    
                        
                    
                    
                </div>
                    <div className='option' style={getRegisterStyle} onMouseOver={showRegister}  onMouseOut={hideRegister}>
                        <div className='option-elements'>
                            <ThemeInput error={isRegisterError} helperText={registerHelperText} id="filled-basic" label="Imie" variant="outlined" fullWidth value={nameVal} onChange={onChangeNameReg}/>
                            
                            <ThemeInput error={isRegisterError} helperText={registerHelperText} id="filled-basic" label="Nazwisko" variant="outlined" fullWidth value={surnameVal} onChange={onChangeSurnameReg}/>

                            <ThemeInput type='email' error={isRegisterError} helperText={registerHelperLogEmailText} id="filled-basic" label="Email" variant="outlined" fullWidth value={emailVal} onChange={onChangeEmailReg}/>

                            <ThemeInput error={isRegisterError} helperText={registerHelperLogEmailText} id="filled-basic" label="Login" variant="outlined" fullWidth value={loginValReg} onChange={onChangeLoginReg}/>

                            <ThemeInput error={isRegisterError} helperText={registerHelperText} id="filled-basic" label="Hasło" variant="outlined" fullWidth  value={passwordValReg} onChange={onChangePasswordReg} type='password'/>

                            <button className='option-btn' onClick={onClickRegister}>
                                <p className='slide-btn-text'>Rejestruj</p>
                            </button>    
                        </div>
                </div>
            </div>
        :
        <div></div>
      }
           
      <div className="option game-options" style={getHumanHumanOptionsStyle} >
            
                <div>Ustawienia rozgrywki Online Człowiek-Człowiek</div>
                <div className='freind-invate'>
                    <select className='friend-select'>
                        <option value="0">Wybierz gracza</option>
                        <option value="1">Jan Nowak</option>
                        <option value="2">Jan Nowak</option>
                        <option value="3">Jan Nowak</option>
                        <option value="4">Jan Nowak</option>
                        <option value="5">Jan Nowak</option>
                        <option value="6">Jan Nowak</option>
                        <option value="7">Jan Nowak</option>
                        <option value="8">Jan Nowak</option>
                        <option value="9">Jan Nowak</option>
                        <option value="10">Jan Nowak</option>
                        <option value="11">Jan Nowak</option>
                        <option value="12">Jan Nowak</option>
                    </select>
                    <button className='option-btn'>Zaproś</button>
                    <button className='option-btn'>Anuluj</button>
                </div>
                <div className='invate-status'>
                    Status zaproszenia: niewysłano
                </div>
                    
                <div>
                    Mój kolor:
                    <select className='friend-select'>
                        <option value="0">Wybierz kolor</option>
                        <option value="1">Czarny</option>
                        <option value="1">Biały</option>
                    </select>
                </div>
                <div>
                    <button className='option-btn' onClick={startGameHumanHumanOnline}>Rozpocznij</button>
                    <button className='option-btn' onClick={hideAdditionalMenu}>Anuluj</button>
                </div>
            
            
      </div>
      <div className="option game-options" style={getTurnBasedOptionsStyle} >
            <p>Ustawienia rozgrywki Turowej Człowiek-Człowiek</p>
      </div>
      <main className="content">
      <div className='chess-piece-info'>
            <div className='piece-text'>
                <div className='piece-header'>
                   Czy wiedziałeś że?
                </div>
                <div className='piece-main-text'>
                    Król w szachach jest jednym z najważniejszych pionków na planszy, ponieważ jego utrata kończy grę. Król może poruszać się o jedno pole w dowolnym kierunku - w górę, w dół, na boki i na skos. Ma również specjalny ruch nazywany roszadą, który pozwala na zamianę pozycji króla i wieży, jeśli oba pionki nie poruszały się wcześniej i nie ma żadnych innych pionków między nimi. Król może również brać udział w szachowaniu i matowaniu przeciwnika. Jego możliwości są ograniczone, ale jego utrata decyduje o wyniku gry.
                </div>
            </div>
        </div>
        <div className='chess-piece-info'>
            <div className='piece'>
                <img className='piece-img' src={king}/>
            </div>
            <div className='piece-text'>
                <div className='piece-header'>
                    Król
                </div>
                <div className='piece-main-text'>
                    Król w szachach jest jednym z najważniejszych pionków na planszy, ponieważ jego utrata kończy grę. Król może poruszać się o jedno pole w dowolnym kierunku - w górę, w dół, na boki i na skos. Ma również specjalny ruch nazywany roszadą, który pozwala na zamianę pozycji króla i wieży, jeśli oba pionki nie poruszały się wcześniej i nie ma żadnych innych pionków między nimi. Król może również brać udział w szachowaniu i matowaniu przeciwnika. Jego możliwości są ograniczone, ale jego utrata decyduje o wyniku gry.
                </div>
            </div>
        </div>
        <div className='chess-piece-info'>
            <div className='piece'>
                    <img className='piece-img' src={queen}/>
                </div>
                <div className='piece-text'>
                    <div className='piece-header'>
                        Hetman
                    </div>
                    <div className='piece-main-text'>
                        Hetman w szachach jest jednym z najpotężniejszych pionków na planszy. Może poruszać się o dowolną liczbę pól w każdym kierunku - w pionie, poziomie i na skos. Dzięki temu, hetman może kontrolować duże obszary planszy i wykonywać skuteczne ataki na przeciwnika. Hetman może również brać udział w szachowaniu i matowaniu przeciwnika. Jego możliwości są bardzo duże, co czyni go cennym pionkiem w grze.
                    </div>
                </div>
        </div>
        <div className='chess-piece-info'>
            <div className='piece'>
                <img className='piece-img' src={bishop}/>
            </div>
            <div className='piece-text'>
                <div className='piece-header'>
                    Goniec
                </div>
                <div className='piece-main-text'>
                Goniec w szachach jest figurą, który porusza się po skosie. Może przesunąć się o dowolną liczbę pól na skosie, zarówno w górę, jak i w dół planszy. Dzięki temu, goniec może kontrolować duże obszary planszy i wykonywać ataki na przeciwnika. Goniec nie może poruszać się po polach innych kolorów, co ogranicza jego możliwości w poruszaniu się po planszy. Goniec może również brać udział w szachowaniu i matowaniu przeciwnika.
                </div>
            </div>
            
        </div>
        <div className='chess-piece-info'>
            <div className='piece'>
                <img className='piece-img' src={horse}/>
            </div>
            <div className='piece-text'>
                <div className='piece-header'>
                    Skoczek
                </div>
                <div className='piece-main-text'>
                    Skoczek w szachach jest pionkiem, który porusza się w kształcie litery "L" - dwie pola na bok i jedno pole w górę lub w dół planszy lub dwie pola w górę lub w dół i jedno pole na bok planszy. Skoczek może przeskakiwać nad innymi pionkami, co daje mu dużą swobodę ruchu na planszy. Skoczek może również brać udział w szachowaniu i matowaniu przeciwnika. Jego możliwości są stosunkowo ograniczone, ale może być bardzo przydatny w strategii gry.
                </div>
            </div>
        </div>
        <div className='chess-piece-info'>
            <div className='piece'>
                <img className='piece-img' src={rook}/>
            </div>
            <div className='piece-text'>
                <div className='piece-header'>
                    Wieża
                </div>
                <div className='piece-main-text'>
                    Wieża w szachach jest figurą, który porusza się w linii prostej, w pionie lub poziomie planszy, o dowolną liczbę pól. Dzięki temu, wieża może kontrolować duże obszary planszy i atakować przeciwnika. Wieża nie może poruszać się po skosie, co ogranicza jej możliwości ruchu na planszy. Wieża może również brać udział w szachowaniu i matowaniu przeciwnika. Jej możliwości ruchu i ataku sprawiają, że jest to ważny pionek w strategii gry.
                </div>
            </div>
        </div>
        <div className='chess-piece-info'>
            <div className='piece'>
                <img className='piece-img' src={pawn}/>
            </div>
            <div className='piece-text'>
                <div className='piece-header'>
                    Pionek
                </div>
                <div className='piece-main-text'>
                    Pionek w szachach porusza się o jedno pole w kierunku przeciwnika, czyli w górę planszy dla białych i w dół dla czarnych. Pionek może również przeskoczyć nad jednym polem, jeśli jest to jego pierwszy ruch. Pionek może atakować przeciwnika tylko po skosie. Jeśli pionek dotrze na ostatni rząd planszy, to może zostać zamieniony na dowolny inny pionek, z wyjątkiem króla. Pionek może również brać udział w szachowaniu i matowaniu przeciwnika, ale jego możliwości ruchu są stosunkowo ograniczone. Pionki są bardzo ważnym elementem gry, ponieważ mogą być wykorzystane jako tarcza ochronna dla innych pionków lub jako narzędzie do blokowania ruchów przeciwnika.
                </div>
            </div>
        </div>

      </main>
    </div>
  );
}

export default Home;
