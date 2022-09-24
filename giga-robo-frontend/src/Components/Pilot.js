const Pilot = ({pilot, selected}) => {
    return (
      <div>
          <button className={`btn btn-primary px-2`} onClick={() => selected(pilot.id)}>{pilot.name}</button>
      </div>
    )
  }
  
  export default Pilot