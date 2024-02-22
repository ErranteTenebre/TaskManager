import React,{useState, useRef} from 'react';
import axios from 'axios';

const RegisterPage = () => {
    const formDataRef = useRef({
        login: '',
        pass: '',
        repass: '',
      });

    const [errorMessages, setErrorMessages] = useState({});
    const registerUser = async (event) => {
        event.preventDefault();
    
        try {
          const response = await axios.post("/api/register", formDataRef.current, {
            headers: { 'Content-Type': 'application/json' }
          });
    
          console.log('Успешный ответ:', response.data);
    
          setErrorMessages({});
        } catch (error) {
          if (error.response && error.response.status === 400) {
            setErrorMessages(error.response.data.errors);
            console.log(error.response.data.errors);
          } else {
            console.error('Ошибка при отправке запроса:', error);
          }
        }
      };


    const handleValueChange = (event) =>{
        const { name, value } = event.target;
    formDataRef.current = {
      ...formDataRef.current,
      [name]: value,
    };
    console.log(formDataRef.current);
    }

        return (
            <main>
                <div className="background">
                    <div className="shape"></div>
                    <div className="shape"></div>
                </div>
                <section className="auth">
                    <div className="register__container">
                        <div className="auth__links">
                            <a className="link" href="/auth/">
                                <span>
                                    Вход
                                </span>
                            </a>
                            <a className="link selected" href="/register/">
                                <span>
                                    Регистрация
                                </span>
                            </a>
                        </div>
                        <div className="auth__form">
                            <form>
                                <div className="auth__field">
                                    <label className="label auth__label" htmlFor="login">Логин</label>
                                    <input
                                    className="input auth__field-input"
                                    id="login"
                                    name="login"
                                    placeholder='Логин'
                                    onChange={handleValueChange}/>
                                </div>
                                {errorMessages && errorMessages.Login && (
                  <div className="error-message">{errorMessages.Login[0]}</div>
                )}
                                <div className="auth__field">
                                    <label className="label auth__label" htmlFor="repass">Пароль</label>
                                    <input
                                    className="input auth__field-input"
                                    id="pass"
                                    name="pass"
                                    type="password"
                                    placeholder='Пароль'
                                    onChange={handleValueChange}
                                     />
                                </div>
                                {errorMessages && errorMessages.Pass && (
                  <div className="error-message">{errorMessages.Pass[0]}</div>
                )}
                                <div className="auth__field">
                                    <label className="label auth__label" htmlFor="repass">Повтор пароля</label>
                                    <input
                                    className="input auth__field-input"
                                    id="repass"
                                    name="repass"
                                    type="password"
                                    placeholder='Повтор пароля'
                                    onChange={handleValueChange}/>
                                </div>
                                {errorMessages && errorMessages.RePass && (
                  <div className="error-message">{errorMessages.RePass[0]}</div>
                )}
                                <button className="submit-button" type="submit" onClick={registerUser}>Зарегистрироваться</button>
                            </form>
                        </div>
                    </div>
                </section>
            </main>
        )
}

export default RegisterPage;