import { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import {
    getEmployee,
    getDepartments,
    updateEmployee
} from "../services/api";


function EditEmployee() {
    const { id } = useParams();
    const navigate = useNavigate();

    const [departments, setDepartments] = useState([]);

    const [employee, setEmployee] = useState({
        FirstName: "",
        LastName: "",
        Email: "",
        Phone: "",
        JobTitle: "",
        DepartmentId: "",
        Salary: ""
    });

    const [loading, setLoading] = useState(true);
    const [error, setError] = useState("");
    useEffect(() => {
        Promise.all([
            getEmployee(id),
            getDepartments()
        ])
            .then(([employeeData, departmentsData]) => {
                setEmployee({
                    FirstName: employeeData.FirstName,
                    LastName: employeeData.LastName,
                    Email: employeeData.Email,
                    Phone: employeeData.Phone || "",
                    JobTitle: employeeData.JobTitle || "",
                    DepartmentId: employeeData.DepartmentId,
                    Salary: employeeData.Salary
                });

                setDepartments(departmentsData);
            })
            .catch(error => {
                console.error(error);
                setError(error.message);
            })
            .finally(() => {
                setLoading(false);
            });
    }, [id]);
    const handleChange = event => {
        const { name, value } = event.target;

        setEmployee({
            ...employee,
            [name]: value
        });
    };

    const handleSubmit = event => {
        event.preventDefault();

        setError("");

        if (
            employee.FirstName.trim() === "" ||
            employee.LastName.trim() === "" ||
            employee.Email.trim() === "" ||
            employee.DepartmentId === "" ||
            employee.Salary === ""
        ) {
            setError("Please fill in all required fields.");
            return;
        }

        if (Number(employee.Salary) < 0) {
            setError("Salary cannot be negative.");
            return;
        }

        updateEmployee(id, {
            ...employee,
            EmployeeId: Number(id),
            DepartmentId: Number(employee.DepartmentId),
            Salary: Number(employee.Salary)
        })
            .then(() => {
                navigate("/employees");
            })
            .catch(error => {
                console.error(error);
                setError(error.message);
            });
    };

    if (loading) {
        return <p>Loading...</p>;
    }

    if (error && !employee.FirstName) {
        return <p>{error}</p>;
    }

    return (
        <div className="form-container">
            <h1>Edit Employee</h1>

            {error && (
                <p className="error-message">
                    {error}
                </p>
            )}

            <form onSubmit={handleSubmit}>

                <div className="form-group">
                    <label>First Name</label>
                    <input
                        name="FirstName"
                        value={employee.FirstName}
                        onChange={handleChange}
                    />
                </div>

                <div className="form-group">
                    <label>Last Name</label>
                    <input
                        name="LastName"
                        value={employee.LastName}
                        onChange={handleChange}
                    />
                </div>

                <div className="form-group">
                    <label>Email</label>
                    <input
                        name="Email"
                        type="email"
                        value={employee.Email}
                        onChange={handleChange}
                    />
                </div>

                <div className="form-group">
                    <label>Phone</label>
                    <input
                        name="Phone"
                        value={employee.Phone}
                        onChange={handleChange}
                    />
                </div>

                <div className="form-group">
                    <label>Job Title</label>
                    <input
                        name="JobTitle"
                        value={employee.JobTitle}
                        onChange={handleChange}
                    />
                </div>

                <div className="form-group">
                    <label>Department</label>

                    <select
                        name="DepartmentId"
                        value={employee.DepartmentId}
                        onChange={handleChange}
                    >
                        <option value="0">
                            Select Department
                        </option>

                        {departments.map(department => (
                            <option
                                key={department.DepartmentId}
                                value={department.DepartmentId}
                            >
                                {department.DepartmentName}
                            </option>
                        ))}
                    </select>
                </div>

                <div className="form-group">
                    <label>Salary</label>
                    <input
                        name="Salary"
                        type="number"
                        value={employee.Salary}
                        onChange={handleChange}
                    />
                </div>

                <div className="form-buttons">
                    <button
                        type="submit"
                        className="primary-button"
                    >
                        Update Employee
                    </button>

                    <button
                        type="button"
                        className="secondary-button"
                        onClick={() => navigate("/employees")}
                    >
                        Cancel
                    </button>
                </div>

            </form>
        </div>
    );
}

export default EditEmployee;