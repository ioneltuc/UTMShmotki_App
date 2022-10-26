import { Link, Outlet } from 'react-router-dom'
import HomeIcon from './HomeIcon';

function Header(){
    return(   
        <>
            <header>
                <nav>
                    <Link to="/">
                        <HomeIcon fontSize="large" />
                        Home
                    </Link>
                    <Link to="/about">About</Link>
                </nav>
            </header>

            <Outlet/>
        </> 
    )
}

export default Header;