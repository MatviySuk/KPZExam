import React, {useState, useEffect } from "react";
import { useParams } from "react-router-dom";

import axios from "axios";
import "./Assignments.css"

const ViewStudents = () => {
    const [data, setData] = useState([]);

    const {id} = useParams(); 

    useEffect(() => {
        if(id) {
            getSASs(id);
        }
    }, [id])

    const getSASs = async (id) => {
        console.log(id)
        const response = await axios.get(`https://localhost:7152/assignments/${id}/get-sas`);
        if (response.status === 200) {
            console.log(response.data)
            setData(response.data)
        }
    };

    return(
        <div style={{marginTop: "150px"}}>
            <table className="styled-table">
                <thead>
                    <tr>
                        <th style={{textAlign: "center"}}>Student Id</th>
                        <th style={{textAlign: "center"}}>Was Present</th>
                        <th style={{textAlign: "center"}}>Mark</th>
                    </tr>
                </thead>
                <tbody>
                     {data && data.map((item, index) => {
                        return (
                            <tr key={item.id}>
                                <td>{item.studentId}</td>
                                <td>{item.isPresent.toString()}</td>
                                <td>{item.mark}</td>
                            </tr>
                        );
                     })}
                </tbody>
            </table>
        </div>
    )
}

export default ViewStudents;