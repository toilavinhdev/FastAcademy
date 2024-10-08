import { Checkbox } from 'antd'

export default function CoursesDurationFilterComponent() {
  return (
    <Checkbox.Group
      options={[
        { label: '0-1 hours', value: 'All' },
        { label: '1-3 hours', value: 'Fresher' },
        { label: '3-6 hours', value: 'Junior' },
        { label: '6-17 hours', value: 'Senior' },
        { label: 'more than 17 hours', value: 'Senior' }
      ]}
      defaultValue={['Apple']}
      onChange={(value) => {
        console.log(value)
      }}
      className='flex flex-col gap-y-3'
    />
  )
}
