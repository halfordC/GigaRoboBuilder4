import Pilot from '././Pilot'

const PilotPicker = ({pilots, pilotSelected}) => {
  return (
    <div className='btn-group'>
        {pilots.map((pilot) => (
            <Pilot pilot={pilot} key={pilot.id} selected={pilotSelected} />
        ))}
    </div>
  )
}

export default PilotPicker