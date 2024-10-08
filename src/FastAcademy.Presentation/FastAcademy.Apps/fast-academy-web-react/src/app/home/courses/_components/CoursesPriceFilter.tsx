import { InputNumber } from 'antd'

export default function CoursesPriceFilterComponent() {
  return (
    <div className='flex items-center justify-between'>
      <InputNumber min={0} defaultValue={0} />
      <div className='h-px bg-gray-300 flex-1 w-full' />
      <InputNumber min={1} defaultValue={100000} />
    </div>
  )
}
