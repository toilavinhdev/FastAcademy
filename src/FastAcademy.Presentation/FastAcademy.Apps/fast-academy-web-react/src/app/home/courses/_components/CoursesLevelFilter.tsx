import { Checkbox } from 'antd'

export default function CoursesLevelFilterComponent() {
  return (
    <Checkbox.Group
      options={[
        { label: 'All', value: 'All' },
        { label: 'Fresher', value: 'Fresher' },
        { label: 'Junior', value: 'Junior' },
        { label: 'Senior', value: 'Senior' }
      ]}
      defaultValue={['Apple']}
      onChange={(value) => {
        console.log(value)
      }}
      className='flex flex-col gap-y-3'
    />
  )
}
