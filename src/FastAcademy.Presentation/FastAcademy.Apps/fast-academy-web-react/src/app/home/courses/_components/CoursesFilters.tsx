import { Collapse } from 'antd'
import CoursesPriceFilterComponent from './CoursesPriceFilter'
import CoursesRateFilterComponent from './CoursesRateFilter'
import CoursesDurationFilterComponent from './CoursesDurationFilter'
import CoursesLevelFilterComponent from './CoursesLevelFilter'

export default function CoursesFilters() {
  return (
    <div>
      <Collapse
        defaultActiveKey={[1, 2, 3, 4]}
        expandIconPosition='end'
        items={[
          {
            key: 1,
            label: 'Rate',
            children: <CoursesRateFilterComponent />
          },
          {
            key: 2,
            label: 'Level',
            children: <CoursesLevelFilterComponent />
          },
          {
            key: 3,
            label: 'Price',
            children: <CoursesPriceFilterComponent />
          },
          {
            key: 4,
            label: 'Duration',
            children: <CoursesDurationFilterComponent />
          }
        ]}
      />
    </div>
  )
}
