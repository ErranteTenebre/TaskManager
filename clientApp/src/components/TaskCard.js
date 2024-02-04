import React from "react";
import axios from 'axios';

const handleTaskDelete =async (taskId, updateTasks) =>{
    const response = await axios.delete(`https://localhost:7002/api/task/${taskId}`);

    if (response.status === 200) console.log("Запись успешно удалена");

    const data =await getTasks();

    updateTasks(data);
}

const getTasks = async() =>{
    const res = await axios.get("https://localhost:7002/api/task");
    const data = res.data;

    return data;
}

const TaskCard = ({title, description, endDate, taskId, updateTasks}) => {
        return (
            <div class="task-card">
            <div class="options-menu">
                <div class="options-trigger">...</div>
                <div class="options-dropdown">
                    <div class="option">Изменить</div>
                    <div class="option" onClick={() => {handleTaskDelete(taskId, updateTasks)}}>Удалить</div>
                </div>
            </div>
            <div class="task-title">{title}</div>
            <div class="task-description">{description}</div>
            <div class="task-due-date">{endDate}</div>
        </div>
        )
}

export default TaskCard;