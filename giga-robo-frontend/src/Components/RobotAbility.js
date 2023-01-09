import React from 'react'
import "./components.css"

const RobotAbility = ({robotAbility, onMouseEnterFunc, robotAbilityMouseLeave, mouseMove}) => {
  return (
    <a className='robotAbilityCards' onMouseEnter={() => onMouseEnterFunc(robotAbility)} onMouseLeave={() => robotAbilityMouseLeave()}
    onMouseMove={mouseMove}>{robotAbility.name}</a>
  )
}

export default RobotAbility
