import React from 'react'
import "./components.css"

const PilotAbility = ({pilotAbility}) => {
  return (
    <a className='pilotAbilityCards'>{pilotAbility.name}</a>
  )
}

export default PilotAbility
