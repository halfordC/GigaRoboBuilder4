import React from 'react'
import "./components.css"

const RobotCard = ({robotCard}) => {
  return (
    <a className='robotCards'>{robotCard.name}</a>
  )
}

export default RobotCard