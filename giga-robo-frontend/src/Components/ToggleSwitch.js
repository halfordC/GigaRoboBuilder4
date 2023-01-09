import React from 'react'
import "./components.css"

const ToggleSwitch = ({ label, filterToggleClick }) => {
    return (
      <div className="toggle-container" >
        {label}{" "}
        <div className="toggle-switch">
          <input type="checkbox" className="checkbox" onClick={() => filterToggleClick()}
                 name={label} id={label} />
          <label className="label" htmlFor={label}>
            <span className="inner" />
            <span className="switch" />
          </label>
        </div>
      </div>
    );
  };
  
export default ToggleSwitch;