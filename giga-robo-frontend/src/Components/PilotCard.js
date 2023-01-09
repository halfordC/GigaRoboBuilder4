import React from 'react'
import "./components.css"

const PilotCard = ({pilotCard, onMouseEnterFunc, pilotCardMouseLeave, mouseMove, pilotCardSelection}) => {
  if(pilotCard.selected == true)
  {
    return (
      <a className='pilotCardSelected' onMouseEnter={() => onMouseEnterFunc(pilotCard)} onMouseLeave={() => pilotCardMouseLeave()} 
      onMouseMove={mouseMove} onClick={() => pilotCardSelection(pilotCard)}>{pilotCard.name}</a>
    )

  }else
  {
    return (
      <a className='pilotCards' onMouseEnter={() => onMouseEnterFunc(pilotCard)} onMouseLeave={() => pilotCardMouseLeave()} 
      onMouseMove={mouseMove} onClick={() => pilotCardSelection(pilotCard)}>{pilotCard.name}</a>
    )

  }

}

export default PilotCard
