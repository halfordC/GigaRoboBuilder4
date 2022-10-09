const Robot = ({robot, selected}) => {
  return (
    <div>
        <button className="btn btn-primary px-2" onClick={() => selected(robot.id)}>{robot.name}</button>
    </div>
  )
}

export default Robot
