import { useState } from "react";
import { useNavigate } from "react-router-dom";
import { login } from "../services/api";
function Login() {
    const navigate = useNavigate();

    const [username, setUsername] = useState("");
    const [password, setPassword] = useState("");
    const [error, setError] = useState("");

    const handleSubmit = event => {
        event.preventDefault();

        setError("");

        login(username, password)
            .then(data => {
                sessionStorage.setItem("userId", data.UserId);
                sessionStorage.setItem("username", data.Username);

                navigate("/");
            })
            .catch(error => {
                console.error(error);
                setError(error.message);
            });
    };
    return (
        <div className="login-container">
            <div className="login-box">
                <h1>Employee Management System</h1>

                <h2>Login</h2>

                {error && (
                    <p className="error-message">
                        {error}
                    </p>
                )}

                <form onSubmit={handleSubmit}>

                    <div className="form-group">
                        <label>Username</label>

                        <input
                            type="text"
                            name="username"
                            value={username}
                            onChange={e => setUsername(e.target.value)}
                        />
                    </div>

                    <div className="form-group">
                        <label>Password</label>

                        <input
                            type="password"
                            name="password"
                            value={password}
                            onChange={e => setPassword(e.target.value)}
                        />
                    </div>

                    <button
                        type="submit"
                        className="primary-button login-button"
                    >
                        Login
                    </button>

                </form>
            </div>
        </div>
    );
}

export default Login;