import React from 'react'
import "./components.css"

const RobotCard = ({robotCard, onMouseEnterFunc, robotCardMouseLeave,mouseMove, robotCardSelection}) => {

  if(robotCard.selected == true) //I don't think this will work. 
  {
    return (<a className='robotCardSelected' onMouseEnter={() => onMouseEnterFunc(robotCard)} onMouseLeave={() => robotCardMouseLeave()}
    onMouseMove={mouseMove} onClick={() => robotCardSelection(robotCard)}>{robotCard.name}</a>)
  }
  else
  {
    return (
      <a className='robotCards' onMouseEnter={() => onMouseEnterFunc(robotCard)} onMouseLeave={() => robotCardMouseLeave()}
      onMouseMove={mouseMove} onClick={() => robotCardSelection(robotCard)}>{robotCard.name}</a>
    )
  }
  
}

export default RobotCard