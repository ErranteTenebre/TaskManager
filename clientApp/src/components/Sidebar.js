import React, { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import { render } from '@testing-library/react';



const Sidebar = ({ user, setUser, setSearchText}) => {
const navigate = useNavigate();

    const logout = async (event) =>{
        event.preventDefault();
        await fetch('/api/logout', {
            method: "POST",
            headers: {
                'Content-Type':'application/json',
            },
            credentials: "include",
        })
    
        setUser('');
        navigate('/auth');
        
    }

    const handleSearchTextChange = (e) =>{
        setSearchText(e.target.value);
    }

    const renderLogOut = () => {
        if (user !== "") {
            return (
                <li className="sidebar__item">
                    <a className="link" href="/auth" onClick={logout}>
                        <i className="fa fa-power-off fa-2x sidebar__icon"></i>
                        <span className="sidebar-text">
                            Выход
                        </span>
                    </a>
                </li>
            );
        } else {
            return null;
        }
    };

    const renderAuthLink = () =>{
        if (user === ""){
           return(
            <li className="sidebar__item">
            <a className="link" href="/auth">
                <i className="fa fa-home fa-2x sidebar__icon"></i>
                <span className="sidebar-text">
                    Авторизация
                </span>
            </a>
        </li> 
           )
        }
    }

    return (
        <nav className="sidebar" style={{top: `80px`}}>
            <ul className="sidebar__list">
                <ul className="sidebar__list">
                   {renderAuthLink()}

                    <li className="sidebar__item">
                        <a className="link" href="#">
                            <i className="fa fa-search fa-2x sidebar__icon"></i>
                            <div className="sidebar-text">
                                <input type="text" placeholder="Поиск" onChange={handleSearchTextChange} />
                            </div>
                        </a>
                    </li>
                </ul>
            </ul>

            <ul className="sidebar__logout">
                {renderLogOut()} 
            </ul>
        </nav>
    );
};

export default Sidebar;