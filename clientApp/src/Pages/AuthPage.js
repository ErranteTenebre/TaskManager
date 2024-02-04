import React, { useState } from 'react';
import axios from 'axios';
import { useNavigate } from 'react-router-dom';

const AuthPage = ({setUser}) => {
    const navigate = useNavigate();

    const [formData, setFormData] = useState({
        login: '',
        pass: '',
    });

    const [authError, setAuthError] = useState('');

    const handleChange = (event) => {
        const { name, value } = event.target;
        setFormData((prevData) => {
            const newData = {
                ...prevData,
                [name]: value,
            };
            console.log(newData); 
            return newData; 
        });
    }

    const handleSubmit = async (event) => {
        event.preventDefault();

        try {
            const response = await axios.post('https://localhost:7002/api/login', formData, {
            headers: { 'Content-Type': 'application/json' },
            withCredentials: true,
        });

        if (response.status === 200){
            const userr =await getUser()
            setUser(userr);
        }

            console.log(response);
    
            navigate('/');
        } catch (error) {
            setAuthError(error.response.data.message);
        }
    };

    const getUser =async () =>{
        const response = await axios.get("https://localhost:7002/api/user",{
            'withCredentials': true,
        });

        const data = response.data;

        return data;
    }

    const guestLogin = () =>{
        navigate('/');
    }

    return (
        <main>
   <div className="background">
        <div className="shape"></div>
        <div className="shape"></div>
    </div>

            <section className="auth">
                <div className="auth__container">
                    <div className="auth__links">
                        <a className="link selected" href="/auth/">
                            <span>
                                Вход
                            </span>
                        </a>
                        <a className="link" href="/register/">
                            <span>
                                Регистрация
                            </span>
                        </a>
                    </div>
                    <div className="auth__form">
                        <form action="#" onSubmit={handleSubmit}>
                            <div className="auth__field">
                                <label className="label auth__label" htmlFor="login">
                                    Логин
                                </label>
                                <input
                                    className="input auth__field-input"
                                    id="login"
                                    name="login"
                                    placeholder='Логин'
                                    onChange={handleChange}
                                />
                            </div>
                            <div className="auth__field">
                                <label className="label auth__label" htmlFor="pass">
                                    Пароль
                                </label>
                                <input
                                    className="input auth__field-input"
                                    type="password"
                                    id="pass"
                                    name="pass"
                                    placeholder='Пароль'
                                    onChange={handleChange}
                                />
                            </div>
                            {authError &&(
                                <div className="error-message">{authError}</div>
                            )
                            }
                            <button className="submit-button" type="submit" onClick={handleSubmit}>Войти</button>
                            <button className="submit-button" type="button" onClick={guestLogin}>Войти как гость</button>
                        </form>
                    </div>
                </div>
            </section>
        </main>
    );
};

export default AuthPage;