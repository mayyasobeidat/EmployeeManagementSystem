import { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import {
    getDepartment,
    updateDepartment
} from "../services/api";


function EditDepartment() {
    const { id } = useParams();
    const navigate = useNavigate();

    const [department, setDepartment] = useState({
        DepartmentName: "",
        Description: ""
    });

    const [loading, setLoading] = useState(true);
    const [error, setError] = useState("");
    useEffect(() => {
        getDepartment(id)
            .then(data => {
                setDepartment({
                    DepartmentName: data.DepartmentName,
                    Description: data.Description || ""
                });
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

        updateDepartment(id, {
            ...department,
            DepartmentId: Number(id)
        })
            .then(() => {
                navigate("/departments");
            })
            .catch(error => {
                console.error(error);
                setError(error.message);
            });
    };

    if (loading) {
        return <p>Loading...</p>;
    }

    if (error && !department.DepartmentName) {
        return <p>{error}</p>;
    }

    return (
        <div className="form-container">
            <h1>Edit Department</h1>

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
                        Update Department
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

export default EditDepartment;