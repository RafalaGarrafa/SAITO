import React, {useState} from 'react';

export const FunctionalComponent = (props) => {

    const[text, setText] = useState("");

    const handleChange = (event) => {
       setText(event.target.value);
    }

    return(
        <div>
            <p>
                Estes es un fuctional Component </p>
                <input type = "password" name = "password" value = {text} onChange = {handleChange} ></input>
                
                {props.propText && <p>{props.propText}</p>}
        </div>
    )
}

export default FunctionalComponent;
