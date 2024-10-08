import { Radio, Rate } from 'antd'
import './CoursesRateFilter.css'

const options = [
  {
    label: '4.5',
    rateValue: 4.5
  },
  {
    label: '4.0',
    rateValue: 4.0
  },
  {
    label: '3.5',
    rateValue: 3.5
  },
  {
    label: '3.0',
    rateValue: 3.0
  }
]

export default function CoursesRateFilterComponent() {
  return (
    <Radio.Group className='space-y-4'>
      {options.map((option, idx) => (
        <Radio key={idx} value={option.rateValue} className='course-rate-filter-item'>
          <Rate disabled allowHalf defaultValue={option.rateValue} className='text-[16px] ml-2' />
          <label className='ml-2'>{option.label} or higher</label>
        </Radio>
      ))}
    </Radio.Group>
  )
}
