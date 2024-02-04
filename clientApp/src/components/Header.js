import React, {useState} from 'react';
import Filter from './Filter';

const Header = ({setFilteredTasks, tasks, setStatus, setDataSort}) => {
    return (
        <header className="header">
            <div className="header__container">

                <Filter setFilteredTasks={setFilteredTasks} tasks={tasks} setStatus={setStatus} setDataSort={setDataSort}/>
                <a className="link">
                    <div className="fa fa-plus"></div>
                </a>
            </div>

        </header>
    );
}

export default Header;