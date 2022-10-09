import React from 'react'
import "./components.css"

const RobotAbility = ({robotAbility}) => {
  return (
    <a className='robotAbilityCards'>{robotAbility.name}</a>
  )
}

export default RobotAbility
