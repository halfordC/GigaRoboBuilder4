import Robot from './Robot'

const RobotPicker = ({robots}) => {
  return (
    <div className='btn-group'>
        {robots.map((robot) => (
            <Robot robot={robot} key={robot.id} />
        ))}
    </div>
  )
}

export default RobotPicker