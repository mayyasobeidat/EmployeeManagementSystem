import { useEffect, useState } from "react";
import { getDashboardStats } from "../services/api";

function Dashboard() {
    const [stats, setStats] = useState(null);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState("");

    useEffect(() => {
        getDashboardStats()
            .then(data => {
                setStats(data);
            })
            .catch(error => {
                console.error(error);
                setError(error.message);
            })
            .finally(() => {
                setLoading(false);
            });
    }, []);

    if (loading) {
        return <p>Loading dashboard...</p>;
    }

    if (error) {
        return <p>{error}</p>;
    }
    return (
        <div className="page-container">
            <div className="page-header">
                <h1>Dashboard</h1>
            </div>

            <p>Welcome to Employee Management System</p>

            <div className="card-container">
                <div className="card">
                    <h2>Total Employees</h2>
                    <p>{stats.EmployeeCount}</p>
                </div>

                <div className="card">
                    <h2>Total Departments</h2>
                    <p>{stats.DepartmentCount}</p>
                </div>
            </div>
        </div>
    );
}

export default Dashboard;