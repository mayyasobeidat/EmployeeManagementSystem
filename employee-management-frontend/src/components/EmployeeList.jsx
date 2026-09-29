import { Link } from "react-router-dom";

function EmployeeList({ employees, onDelete }) {
    return (
        <div className="table-container">
        <table border="1">
            <thead>
                <tr>
                    <th>ID</th>
                    <th>First Name</th>
                    <th>Last Name</th>
                    <th>Job Title</th>
                    <th>Department</th>
                    <th>Email</th>
                    <th>Salary</th>
                    <th>Details</th>
                    <th>Edit</th>
                    <th>Delete</th>
                </tr>
            </thead>

            <tbody>
                {employees.map(employee => (
                    <tr key={employee.EmployeeId}>
                        <td>{employee.EmployeeId}</td>
                        <td>{employee.FirstName}</td>
                        <td>{employee.LastName}</td>
                        <td>{employee.JobTitle}</td>
                        <td>{employee.DepartmentName}</td>
                        <td>{employee.Email}</td>
                        <td>{employee.Salary}</td>

                        <td>
                            <Link to={`/employees/${employee.EmployeeId}`} className="table-action">
                                Details
                            </Link>
                        </td>

                        <td>
                            <Link to={`/employees/${employee.EmployeeId}/edit`} className="table-action">
                                Edit
                            </Link>
                        </td>

                        <td>
                            <button
                                onClick={() => onDelete(employee.EmployeeId)} className="table-action"
                            >
                                Delete
                            </button>
                        </td>
                    </tr>
                ))}
            </tbody>
            </table>
        </div>
    );
}

export default EmployeeList;