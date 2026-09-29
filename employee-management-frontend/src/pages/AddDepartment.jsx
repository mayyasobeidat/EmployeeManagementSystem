import { useState } from "react";
import { useNavigate } from "react-router-dom";
import { addDepartment } from "../services/api";
function AddDepartment() {
    const navigate = useNavigate();

    const [department, setDepartment] = useState({
        DepartmentName: "",
        Description: ""
    });

    const [error, setError] = useState("");

    const handleChange = event => {
        const { name, value } = event.target;

        setDepartment({
            ...department,
            [name]: value
        });
    };
    const handleSubmit = event => {
        event.preventDefault();

        setError("");

        if (department.DepartmentName.trim() === "") {
            setError("Department name is required.");
            return;
        }

        addDepartment(department)
            .then(() => {
                navigate("/departments");
            })
            .catch(error => {
                console.error(error);
                setError(error.message);
            });
    };

    return (
        <div className="form-container">
            <h1>Add Department</h1>

            {error && (
                <p className="error-message">
                    {error}
                </p>
            )}

            <form onSubmit={handleSubmit}>

                <div className="form-group">
                    <label>Department Name</label>

                    <input
                        name="DepartmentName"
                        value={department.DepartmentName}
                        onChange={handleChange}
                    />
                </div>

                <div className="form-group">
                    <label>Description</label>

                    <textarea
                        name="Description"
                        value={department.Description}
                        onChange={handleChange}
                    />
                </div>

                <div className="form-buttons">
                    <button
                        type="submit"
                        className="primary-button"
                    >
                        Add Department
                    </button>

                    <button
                        type="button"
                        className="secondary-button"
                        onClick={() => navigate("/departments")}
                    >
                        Cancel
                    </button>
                </div>

            </form>
        </div>
    );
}

export default AddDepartment;