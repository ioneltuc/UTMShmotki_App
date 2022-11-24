import { useEffect, useState } from 'react';
import { Link, Outlet, useNavigate } from 'react-router-dom'
import { getUser, logout } from '../services/authService';
import HomeIcon from './HomeIcon';

function Header(){

    const navigate = useNavigate();
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
        await logout()
        setUser('')
        navigate('/', {replace: true})
    }

    return(   
        <>
            <header>
                <nav>
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
                                <span id="username">{user}</span>
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