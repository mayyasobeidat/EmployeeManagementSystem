function EmployeeSearch({
    search,
    setSearch,
    departmentId,
    setDepartmentId,
    departments,
    onSearch,
    onClear
}) {
    return (
        <div className="search-panel">
            <input
                type="text"
                placeholder="Search employees..."
                value={search}
                onChange={e => setSearch(e.target.value)}
            />

            <select
                value={departmentId}
                onChange={e => setDepartmentId(e.target.value)}
            >
                <option value="0">All Departments</option>

                {departments.map(department => (
                    <option
                        key={department.DepartmentId}
                        value={department.DepartmentId}
                    >
                        {department.DepartmentName}
                    </option>
                ))}
            </select>

            <button
                className="primary-button"
                onClick={onSearch}
            >
                Search
            </button>

            <button
                className="secondary-button"
                onClick={onClear}
            >
                Clear
            </button>
        </div>
    );
}

export default EmployeeSearch;