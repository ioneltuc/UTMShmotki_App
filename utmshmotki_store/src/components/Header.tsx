import { useEffect, useState } from 'react';
import { Link, Outlet } from 'react-router-dom'
import { getUser } from '../services/authService';
import HomeIcon from './HomeIcon';

function Header(){
    const [user, setUser] = useState('')
    useEffect(() => {
        (
            async () => {
                const response = await getUser()
                setUser(response.userName)
            }
        )()
    })

    return(   
        <>
            <header>
                <nav>
                    {user ? "HELLO " + user : "NOT LOGGED"}
                    <Link to="/" className='nav-btn'>
                        <HomeIcon sx={{ fontSize: 30 }} />
                        Home
                    </Link>
                    <Link to="/about" className='nav-btn'>
                        About
                    </Link>
                    <Link to="/login" className='nav-btn'>
                        LogIn
                    </Link>
                </nav>
            </header>

            <Outlet/>
        </> 
    )
}

export default Header;