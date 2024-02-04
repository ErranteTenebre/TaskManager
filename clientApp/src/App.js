import React, { useState,useEffect } from 'react';
import { Route, Routes, useNavigate } from 'react-router-dom';
import axios from 'axios';
import TasksPage from './Pages/TasksPage';
import AuthPage from './Pages/AuthPage';
import RegisterPage from './Pages/RegisterPage';


function App() {
  const [user, setUser] = useState('');
  const [isLoading, setIsLoading] = useState(true);

  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await axios.get('https://localhost:7002/api/user', {
          headers: { 'Content-Type': 'application/json' },
          withCredentials: true,
        });

        setUser(response.data);
       
      } catch {
        
      } finally {
        setIsLoading(false); 
      }
    };

    fetchData();
  }, []);

  if (isLoading) {
    return <div>Loading...</div>;
  }

  return (
    <Routes>
      {/* Добавьте маршрут для страницы задач */}
      <Route path="/" element={<TasksPage user={user} setUser={setUser} />} />

      {/* Добавьте маршрут для страницы аутентификации */}
      <Route path="/auth" element={<AuthPage setUser={setUser}/>} />

      {/* Добавьте маршрут для страницы регистрации */}
      <Route path="/register" element={<RegisterPage />} />
    </Routes>
  );
}

export default App;
