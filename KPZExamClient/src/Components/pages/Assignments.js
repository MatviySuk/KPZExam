import React, {useState, useEffect} from "react";
import { Link } from "react-router-dom";
import "./Assignments.css"
import axios from "axios";
import { toast } from "react-toastify";

const Assignments = () => {
    const [data, setData] = useState([]);

    useEffect(() => {
        getAssignments();
    });

    const getAssignments = async () => {
        const response = await axios.get("https://localhost:7152/assignments");
        if (response.status === 200) {
            setData(response.data)
        }
    };

    const onDeleteAssignment = async (id) => {
        if(window.confirm("Are you sure to delete the assignment?")) {
            const response = await axios.delete(`https://localhost:7152/assignments/${id}`);
            if(response.status === 200) {
                toast.success(response.data);
                getAssignments();
            }
        }
    }

    return(
        <div style={{marginTop: "150px"}}>
            <table className="styled-table">
                <thead>
                    <tr>
                        <th style={{textAlign: "center"}}>Text</th>
                        <th style={{textAlign: "center"}}>DateTime</th>
                        <th style={{textAlign: "center"}}>Priority</th>
                        <th style={{textAlign: "center"}}>Status</th>
                        <th style={{textAlign: "center"}}>Actions</th>
                    </tr>
                </thead>
                <tbody>
                     {data && data.map((item, index) => {
                        return (
                            <tr key={item.id}>
                                <td>{item.text}</td>
                                <td>{item.dateTime}</td>
                                <td>{item.priority}</td>
                                <td>{item.status}</td>
                                <td>
                                    <Link to={`/viewStudents/${item.id}`}>
                                        <button className="btn btn-view">View Students</button>
                                    </Link>
                                    <Link to={`/update/${item.id}`}>
                                        <button className="btn btn-edit">Edit</button>
                                    </Link>
                                        <button className="btn btn-delete" onClick={() => onDeleteAssignment(item.id)}>Delete</button>
                                </td>
                            </tr>
                        );
                     })}
                </tbody>
            </table>
        </div>
    )
}

export default Assignments;