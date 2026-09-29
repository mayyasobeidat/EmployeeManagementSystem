import { BrowserRouter, Routes, Route, Link } from "react-router-dom";
import Dashboard from "./pages/Dashboard";
import Employees from "./pages/Employees";
import EmployeeDetails from "./pages/EmployeeDetails";
import Departments from "./pages/Departments";
import AddEmployee from "./pages/AddEmployee";
import EditEmployee from "./pages/EditEmployee";
import AddDepartment from "./pages/AddDepartment";
import EditDepartment from "./pages/EditDepartment";
import Login from "./pages/Login";
import ProtectedRoute from "./components/ProtectedRoute";
import { useNavigate } from "react-router-dom";
import "./styles/app.css";
function Navigation() {
    const navigate = useNavigate();

    const userId = sessionStorage.getItem("userId");
    const username = sessionStorage.getItem("username");

    const handleLogout = () => {
        sessionStorage.clear();
        navigate("/login");
    };

    return (
        <nav className="navbar">
            <div className="navbar-brand">
                Employee Management System
            </div>

            {userId && (
                <div className="navbar-links">
                    <Link to="/">Dashboard</Link>
                    <Link to="/employees">Employees</Link>
                    <Link to="/departments">Departments</Link>

                    <span className="navbar-user">
                        {username}
                    </span>

                    <button
                        className="logout-button"
                        onClick={handleLogout}
                    >
                        Logout
                    </button>
                </div>
            )}
        </nav>
    );
}
function App() {
    return (
        <BrowserRouter>
            <Navigation />

            <Routes>
                <Route
                    path="/login"
                    element={<Login />}
                />

                <Route
                    path="/"
                    element={
                        <ProtectedRoute>
                            <Dashboard />
                        </ProtectedRoute>
                    }
                />

                <Route
                    path="/employees"
                    element={
                        <ProtectedRoute>
                            <Employees />
                        </ProtectedRoute>
                    }
                />

                <Route
                    path="/employees/add"
                    element={
                        <ProtectedRoute>
                            <AddEmployee />
                        </ProtectedRoute>
                    }
                />

                <Route
                    path="/employees/:id/edit"
                    element={
                        <ProtectedRoute>
                            <EditEmployee />
                        </ProtectedRoute>
                    }
                />

                <Route
                    path="/employees/:id"
                    element={
                        <ProtectedRoute>
                            <EmployeeDetails />
                        </ProtectedRoute>
                    }
                />

                <Route
                    path="/departments"
                    element={
                        <ProtectedRoute>
                            <Departments />
                        </ProtectedRoute>
                    }
                />

                <Route
                    path="/departments/add"
                    element={
                        <ProtectedRoute>
                            <AddDepartment />
                        </ProtectedRoute>
                    }
                />

                <Route
                    path="/departments/:id/edit"
                    element={
                        <ProtectedRoute>
                            <EditDepartment />
                        </ProtectedRoute>
                    }
                />
            </Routes>
        </BrowserRouter>
    );
}

export default App;