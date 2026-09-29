import { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import EmployeeList from "../components/EmployeeList";
import EmployeeSearch from "../components/EmployeeSearch";
import {
    getEmployees,
    getDepartments,
    searchEmployees,
    deleteEmployee
} from "../services/api";

function Employees() {
    const [employees, setEmployees] = useState([]);
    const [departments, setDepartments] = useState([]);

    const [search, setSearch] = useState("");
    const [departmentId, setDepartmentId] = useState("0");

    const [loading, setLoading] = useState(true);
    const [error, setError] = useState("");

    useEffect(() => {
        setLoading(true);
        setError("");

        Promise.all([
            getEmployees(),
            getDepartments()
        ])
            .then(([employeesData, departmentsData]) => {
                setEmployees(employeesData);
                setDepartments(departmentsData);
            })
            .catch(error => {
                console.error(error);
                setError(error.message);
            })
            .finally(() => {
                setLoading(false);
            });
    }, []);

    const handleSearch = () => {
        setLoading(true);
        setError("");

        searchEmployees(search, departmentId)
            .then(data => {
                setEmployees(data);
            })
            .catch(error => {
                console.error(error);
                setError(error.message);
            })
            .finally(() => {
                setLoading(false);
            });
    };


    const handleClear = () => {
        setSearch("");
        setDepartmentId("0");
        setLoading(true);
        setError("");

        getEmployees()
            .then(data => {
                setEmployees(data);
            })
            .catch(error => {
                console.error(error);
                setError(error.message);
            })
            .finally(() => {
                setLoading(false);
            });
    };
    const handleDelete = id => {
        const confirmed = window.confirm(
            "Are you sure you want to delete this employee?"
        );

        if (!confirmed) {
            return;
        }

        deleteEmployee(id)
            .then(() => {
                setEmployees(
                    employees.filter(
                        employee => employee.EmployeeId !== id
                    )
                );
            })
            .catch(error => {
                console.error(error);
                setError(error.message);
            });
    };

    return (
        <div className="page-container">
            <div className="page-header">
                <h1>Employees</h1>

                <Link
                    to="/employees/add"
                    className="primary-button"
                >
                    + Add Employee
                </Link>
            </div>

            {loading && <p>Loading...</p>}

            {error && (
                <p className="error-message">
                    {error}
                </p>
            )}

            <EmployeeSearch
                search={search}
                setSearch={setSearch}
                departmentId={departmentId}
                setDepartmentId={setDepartmentId}
                departments={departments}
                onSearch={handleSearch}
                onClear={handleClear}
            />

            <br />

            <EmployeeList
                employees={employees}
                onDelete={handleDelete}
            />
        </div>
    );
}

export default Employees;