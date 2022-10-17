import React from 'react'
import "./components.css"

const RobotCard = ({robotCard, onMouseEnterFunc, robotCardMouseLeave,mouseMove}) => {

  return (
    <a className='robotCards' onMouseEnter={() => onMouseEnterFunc(robotCard)} onMouseLeave={() => robotCardMouseLeave()}
    onMouseMove={mouseMove}>{robotCard.name}</a>
  )
}

export default RobotCard

//onMouseLeave={() => robotCardMouseLeave()}