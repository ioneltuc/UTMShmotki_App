import { Link, Outlet } from 'react-router-dom'
import HomeIcon from './HomeIcon';

function Header(){
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
                </nav>
            </header>

            <Outlet/>
        </> 
    )
}

export default Header;