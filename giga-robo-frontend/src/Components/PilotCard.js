import React from 'react'
import "./components.css"

const PilotCard = ({pilotCard}) => {
  return (
    <a className='pilotCards'>{pilotCard.name}</a>
  )
}

export default PilotCard
