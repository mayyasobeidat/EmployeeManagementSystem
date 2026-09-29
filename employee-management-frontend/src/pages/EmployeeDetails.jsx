import { useEffect, useState } from "react";
import { useParams, Link } from "react-router-dom";
import { getEmployee } from "../services/api";
function EmployeeDetails() {
    const { id } = useParams();

    const [employee, setEmployee] = useState(null);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState("");

    useEffect(() => {
        getEmployee(id)
            .then(data => {
                setEmployee(data);
            })
            .catch(error => {
                console.error(error);
                setError(error.message);
            })
            .finally(() => {
                setLoading(false);
            });
    }, [id]);

    if (loading) {
        return <p>Loading...</p>;
    }

    if (error) {
        return <p>{error}</p>;
    }

    return (
        <div className="page-container">
            <div className="page-header">
                <h1>Employee Details</h1>

                <Link
                    to="/employees"
                    className="secondary-button"
                >
                    ← Back to Employees
                </Link>
            </div>

            <div className="details-card">
                <div className="details-row">
                    <strong>ID:</strong>
                    <span>{employee.EmployeeId}</span>
                </div>

                <div className="details-row">
                    <strong>First Name:</strong>
                    <span>{employee.FirstName}</span>
                </div>

                <div className="details-row">
                    <strong>Last Name:</strong>
                    <span>{employee.LastName}</span>
                </div>

                <div className="details-row">
                    <strong>Email:</strong>
                    <span>{employee.Email}</span>
                </div>

                <div className="details-row">
                    <strong>Phone:</strong>
                    <span>{employee.Phone}</span>
                </div>

                <div className="details-row">
                    <strong>Job Title:</strong>
                    <span>{employee.JobTitle}</span>
                </div>

                <div className="details-row">
                    <strong>Department:</strong>
                    <span>{employee.DepartmentName}</span>
                </div>

                <div className="details-row">
                    <strong>Salary:</strong>
                    <span>{employee.Salary}</span>
                </div>

                <div className="details-row">
                    <strong>Hire Date:</strong>
                    <span>
                        {new Date(employee.HireDate).toLocaleDateString()}
                    </span>
                </div>

                <div className="details-row">
                    <strong>Status:</strong>
                    <span>
                        {employee.IsActive ? "Active" : "Inactive"}
                    </span>
                </div>
            </div>
        </div>
    );
}

export default EmployeeDetails;