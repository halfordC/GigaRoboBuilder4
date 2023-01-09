import React from 'react'
import "./components.css"

const PilotAbility = ({pilotAbility, onMouseEnterFunc, pilotAbilityMouseLeave, mouseMove}) => {
  return (
    <a className='pilotAbilityCards' onMouseEnter={() => onMouseEnterFunc(pilotAbility)} onMouseLeave={() => pilotAbilityMouseLeave()}
    onMouseMove={mouseMove}>{pilotAbility.name}</a>
  )
}

export default PilotAbility
