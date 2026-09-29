const API_URL = "https://localhost:44374/api";

export async function getEmployees() {
    const response = await fetch(`${API_URL}/employees`);

    if (!response.ok) {
        throw new Error("Failed to load employees.");
    }

    return response.json();
}

export async function getEmployee(id) {
    const response = await fetch(`${API_URL}/employees/${id}`);

    if (!response.ok) {
        throw new Error("Employee not found.");
    }

    return response.json();
}

export async function addEmployee(employee) {
    const response = await fetch(`${API_URL}/employees`, {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(employee)
    });

    if (!response.ok) {
        throw new Error("Failed to add employee.");
    }

    return response.json();
}

export async function updateEmployee(id, employee) {
    const response = await fetch(`${API_URL}/employees/${id}`, {
        method: "PUT",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(employee)
    });

    if (!response.ok) {
        throw new Error("Failed to update employee.");
    }

    return response.json();
}

export async function deleteEmployee(id) {
    const response = await fetch(`${API_URL}/employees/${id}`, {
        method: "DELETE"
    });

    if (!response.ok) {
        throw new Error("Failed to delete employee.");
    }
}

export async function getDepartments() {
    const response = await fetch(`${API_URL}/departments`);

    if (!response.ok) {
        throw new Error("Failed to load departments.");
    }

    return response.json();
}

export async function getDepartment(id) {
    const response = await fetch(`${API_URL}/departments/${id}`);

    if (!response.ok) {
        throw new Error("Department not found.");
    }

    return response.json();
}

export async function addDepartment(department) {
    const response = await fetch(`${API_URL}/departments`, {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(department)
    });

    if (!response.ok) {
        throw new Error("Failed to add department.");
    }

    return response.json();
}

export async function updateDepartment(id, department) {
    const response = await fetch(`${API_URL}/departments/${id}`, {
        method: "PUT",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(department)
    });

    if (!response.ok) {
        throw new Error("Failed to update department.");
    }

    return response.json();
}

export async function deleteDepartment(id) {
    const response = await fetch(`${API_URL}/departments/${id}`, {
        method: "DELETE"
    });

    if (!response.ok) {
        const data = await response.json();

        throw new Error(
            data.Message || "Failed to delete department."
        );
    }
}

export async function login(username, password) {
    const response = await fetch(`${API_URL}/auth/login`, {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({
            Username: username,
            Password: password
        })
    });

    if (!response.ok) {
        if (response.status === 401) {
            throw new Error("Invalid username or password.");
        }

        throw new Error("Login failed.");
    }

    return response.json();
}

export async function searchEmployees(search, departmentId) {
    const response = await fetch(
        `${API_URL}/employees/search?search=${encodeURIComponent(search)}&departmentId=${departmentId}`
    );

    if (!response.ok) {
        throw new Error("Failed to search employees.");
    }

    return response.json();
}

export async function getDashboardStats() {
    const response = await fetch(`${API_URL}/dashboard/stats`);

    if (!response.ok) {
        throw new Error("Failed to load dashboard statistics.");
    }

    return response.json();
}