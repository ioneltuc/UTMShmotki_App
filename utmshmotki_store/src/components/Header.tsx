import { useEffect, useState } from 'react';
import { Link, Outlet } from 'react-router-dom'
import { getUser, logout } from '../services/authService';
import HomeIcon from './HomeIcon';
import placeholder from '../assets/images/product_placeholder.png'
import AccountCircleIcon from '@mui/icons-material/AccountCircle';

function Header(){

    const [user, setUser] = useState('')

    useEffect(() => {
        (
            async () => {
                const response = await getUser()
                setUser(response.userName)
            }
        )()
    }, [user])

    const logoutHandler = async () => {
        setUser('')
        await logout()
    }

    return(   
        <>
            <header>
                <nav>
                    <Link to="/" className='header-logo nav-btn'>
                        <img src={placeholder} width="45px"/>
                        <h1>UTMShmotki</h1>
                    </Link>
                    <Link to="/" className='nav-btn'> 
                        <HomeIcon sx={{ fontSize: 30 }} />                    
                        Home   
                    </Link>
                    <Link to="/about" className='nav-btn'>
                        About
                    </Link>
                    <div className="credentials-header">
                    {
                        user
                        ? 
                        <>
                            <span id="username">{user}
                                <AccountCircleIcon />
                            </span>
                            <Link to="/login" onClick={logoutHandler} className='nav-btn'>
                                Logout
                            </Link>
                        </>
                        :  
                        <Link to="/login" className='nav-btn'>
                            Login
                        </Link>
                    }
                    </div>
                </nav>
            </header>

            <Outlet/>
        </> 
    )
}

export default Header;