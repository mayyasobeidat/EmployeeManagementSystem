import { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import {
    getDepartments,
    deleteDepartment
} from "../services/api";
function Departments() {
    const [departments, setDepartments] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState("");
    const loadDepartments = () => {
        setLoading(true);
        setError("");

        getDepartments()
            .then(data => {
                setDepartments(data);
            })
            .catch(error => {
                console.error(error);
                setError(error.message);
            })
            .finally(() => {
                setLoading(false);
            });
    };
    useEffect(() => {
        loadDepartments();
    }, []);

    const handleDelete = id => {
        const confirmed = window.confirm(
            "Are you sure you want to delete this department?"
        );

        if (!confirmed) {
            return;
        }

        deleteDepartment(id)
            .then(() => {
                loadDepartments();
            })
            .catch(error => {
                console.error(error);
                setError(error.message);
            });
    };
    if (loading) {
        return <p>Loading...</p>;
    }

    return (
        <div className="page-container">
            <div className="page-header">
                <h1>Departments</h1>

                <Link
                    to="/departments/add"
                    className="primary-button"
                >
                    + Add Department
                </Link>
            </div>

            {error && (
                <p className="error-message">
                    {error}
                </p>
            )}

            <div className="table-container">
                <table>
                    <thead>
                        <tr>
                            <th>ID</th>
                            <th>Department Name</th>
                            <th>Description</th>
                            <th>Edit</th>
                            <th>Delete</th>
                        </tr>
                    </thead>

                    <tbody>
                        {departments.map(department => (
                            <tr key={department.DepartmentId}>
                                <td>{department.DepartmentId}</td>
                                <td>{department.DepartmentName}</td>
                                <td>{department.Description}</td>

                                <td>
                                    <Link
                                        to={`/departments/${department.DepartmentId}/edit`}
                                        className="table-action"
                                    >
                                        Edit
                                    </Link>
                                </td>

                                <td>
                                    <button
                                        className="table-action"
                                        onClick={() =>
                                            handleDelete(department.DepartmentId)
                                        }
                                    >
                                        Delete
                                    </button>
                                </td>
                            </tr>
                        ))}
                    </tbody>
                </table>
            </div>
        </div>
    );
}

export default Departments;