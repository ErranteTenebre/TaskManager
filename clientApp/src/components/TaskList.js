import React, { useState, useEffect } from 'react';
import TaskCard from './TaskCard';


const formatDate = (dateString) => {
    const options = { year: 'numeric', month: 'numeric', day: 'numeric' };
    return new Date(dateString).toLocaleDateString(undefined, options);
  };
  

const TaskList = ({ tasks, loading, updateTasks}) => {
    if (loading) {
        return(<h2>Загрузка...</h2>)
    }
    return (
        <div className="task-list">
            {tasks.map(task => (
                <TaskCard
                key={task.id} 
                taskId={task.id} 
                title={task.title}
                description={task.description}
                endDate={formatDate(task.endDate)}
                updateTasks={updateTasks}/>
            ))}
        </div>
    )

}


        


export default TaskList;