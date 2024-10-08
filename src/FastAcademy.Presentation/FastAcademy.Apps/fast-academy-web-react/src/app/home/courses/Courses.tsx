import { useNavigate } from 'react-router-dom'
import { CourseComponent, PaginatorComponent } from '~/shared/components'
import CoursesFilters from './_components/CoursesFilters'

export default function Courses() {
  const navigate = useNavigate()

  const navigateToCourseDetail = (courseId: string) => {
    navigate(`/courses/${courseId}`)
  }

  return (
    <div id='courses-container' className='grid grid-cols-12 gap-x-5'>
      <div className='col-span-3'>
        <CoursesFilters />
      </div>
      <div className='col-span-9'>
        <div className='grid sm:grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-5'>
          {Array.from({ length: 17 }).map((_, idx) => (
            <CourseComponent key={idx} onClick={() => navigateToCourseDetail('123')} />
          ))}
        </div>
        <PaginatorComponent />
      </div>
    </div>
  )
}
