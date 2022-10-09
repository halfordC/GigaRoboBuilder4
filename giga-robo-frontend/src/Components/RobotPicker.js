import Robot from './Robot'

const RobotPicker = ({robots, robotSelected}) => {
  return (
    <div className='btn-group'>
        {robots.map((robot) => (
            <Robot robot={robot} key={robot.id} selected={robotSelected} />
        ))}
    </div>
  )
}

export default RobotPicker