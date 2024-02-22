import React, { useState, useEffect } from 'react';
import axios from 'axios';

import Header from '../components/Header';
import Sidebar from '../components/Sidebar';
import TaskList from '../components/TaskList';
import Pagination from '../components/Pagination';

const TasksPage = ({user, setUser}) => {
    const [loading, setLoading] = useState(false);
    const [currentPage, setCurrentpage] = useState(1);
    const [tasksPerPage, setTasksPerPage] = useState(8);
    const [Alltasks, setTasks] = useState([]);
    const [filteredTasks, setFilteredTasks] = useState([]);
    const [status, setStatus] = useState("any");
    const [searchText, setSearchText] = useState('');
    const [dateSort, setDataSort] = useState('');

    const lastTaskIndex = tasksPerPage * currentPage;
    const firstTaskIndex = tasksPerPage * currentPage - tasksPerPage;
    const currentTasks = filteredTasks.slice(firstTaskIndex, lastTaskIndex);
    const pagesCount = Math.ceil(filteredTasks.length / tasksPerPage);

    const paginate = (pageNumber) => {
        setCurrentpage(pageNumber);
    }

    const filterByStatus = (status, tasksToFilter) =>{
        return tasksToFilter.filter(task =>{
            return task.status.name === status;
        });
    }

    const filterByDescrOrTitle =( searchText, tasksToFilter) =>{
        return tasksToFilter.filter((task) =>{
            return task.title.includes(searchText) || task.description.includes(searchText);
        })
    }

    const sortByEndDate = (tasks, dateSort) =>{
        if (dateSort === "ascending")
        {
            tasks.sort((task1, task2) => task1.endDate.localeCompare(task2.endDate));
        }
        else if (dateSort === "descending")
        {
            tasks.sort((task1, task2) => task2.endDate.localeCompare(task1.endDate));
        }
        return tasks;
    }

    useEffect(() => {
        const getTasks = async () => {
            setLoading(true);
            const res = await axios.get("/api/task");
            const data = res.data;
            setTasks(data);
            setLoading(false);
        }
        getTasks();
    }, [])

     useEffect( ()=>{
        let tasksToFilter = Alltasks;
        if (status != "any"){
            tasksToFilter = filterByStatus(status, tasksToFilter);
        }

        if (searchText != ''){
            tasksToFilter = filterByDescrOrTitle(searchText, tasksToFilter);
        }

        if (dateSort !== ''){
            tasksToFilter = sortByEndDate(tasksToFilter, dateSort);
        }

        

        setFilteredTasks(tasksToFilter);
        setCurrentpage(1);
     }, [Alltasks,status,searchText, dateSort])

    return (
        <div>
            <Header setFilteredTasks={setFilteredTasks} tasks={Alltasks} setStatus={setStatus} setDataSort={setDataSort}/>
            <Sidebar user={user} setUser={setUser} setSearchText={setSearchText}/>
            <main>
                <div className="tasks" style={{ paddingTop: "80px", marginLeft: '60px' }}>
                    <div className="tasks__content">
                        <TaskList tasks={currentTasks} updateTasks={setTasks} />
                        <Pagination currentPage={currentPage} totalPages={pagesCount} onPageChange={paginate} />
                    </div>
                </div>
            </main>
        </div>
    );
};

export default TasksPage;  