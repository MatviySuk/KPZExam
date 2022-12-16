import React, {useState, useEffect} from "react";
import { useNavigate, useLocation, useParams } from "react-router-dom";
import axios from "axios";
import './AddEdit.css'
import { toast } from "react-toastify";

const initialState = {
    ID: 0,
    text: "",
    dateTime: new Date(),
    priority: 0,
    status: 0 
}

const AddEdit = () => {
    const [state, setState] = useState(initialState);

    const { text, dateTime, priority, status } = state;

    const navigate = useNavigate();

    const {id} = useParams(); 

    useEffect(() => {
        if(id) {
            getSingleAssignment(id);
        }
    }, [id])

    const getSingleAssignment = async (id) => {
        const response = await axios.get(`https://localhost:7152/assignments/${id}`);
            if(response.status === 200) {
                setState({ ...response.data });
            }
    }
     

    const addAssignment = async (data) => {
        const response = await axios.post("https://localhost:7152/assignments", {
            text: data.text,
            dateTime: data.dateTime,
            priority: data.priority,
            status: data.status
        })
        if(response.status === 200) {
            toast.success(response.data);
        }
    }; 

    const updateAssignment = async (data, id) => {
        const response = await axios.put("https://localhost:7152/assignments", {
            ID: id,
            text: data.text,
            dateTime: data.dateTime,
            priority: data.priority,
            status: data.status
        })
        if(response.status === 200) {
            toast.success(response.data);
        }
    }

    const handleSubmit = (e) => {
        e.preventDefault();
        if(!text || !dateTime || !priority || !status) {
            toast.error("Please fill up the fields!");
        } else { 
            if(!id) {
                addAssignment(state);
            } else {
                updateAssignment(state, id);
            }
            navigate('/');
        }
    }

    const handleInputChange = (e) => {
        let {name, value} = e.target;
        setState({...state, [name]: value,  })
    }

    return( 
        <div style={{marginTop: "100px"}}>
            <form 
                style={{
                    margin: "auto",
                    padding: "15px",
                    maxWidth: "400px",
                    alignContent: "center",
                }}
                onSubmit={handleSubmit}
            >
                <label htmlFor="text">Text</label>
                <input 
                    type="text" 
                    id="text" 
                    name="text"
                    placeholder="Enter text ..." 
                    onChange={handleInputChange} 
                    value={text}
                    />

                <label htmlFor="datetime">DateTime</label>
                <input 
                    type="datetime-local" 
                    id="datetime" 
                    name="datetime"
                    placeholder="Enter Date Time ..." 
                    onChange={handleInputChange} 
                    value={dateTime}
                    />

                <label htmlFor="number">Priority</label>
                <input 
                    type="number" 
                    id="priority" 
                    name="priority"
                    placeholder="Enter priority ..." 
                    onChange={handleInputChange} 
                    value={priority}
                    />

                <label htmlFor="number">Status</label>
                <input 
                    type="number" 
                    id="status" 
                    name="status"
                    placeholder="Enter status ..." 
                    onChange={handleInputChange} 
                    value={status}
                    />
                <input type="submit" value={id ? "Update" : "Add"} />
            </form>
        </div>
    );
};

export default AddEdit;