import { focusOptions } from './hooks/useStatusForm';

export function FocusSelector({ value, onChange }) {
  return (
    <div>
      <label className="text-xs text-gray-400 mb-3 block italic">
        Nível de foco
      </label>
      <div className="grid grid-cols-3 gap-4">
        {focusOptions.map((opt) => (
          <button
            key={opt.id}
            type="button"
            onClick={() => onChange(opt.id)}
            className={`py-4 rounded-2xl text-xs font-bold border transition-all ${
              value === opt.id 
                ? 'bg-white border-gray-200 shadow-sm' 
                : 'bg-[#F9F9F9] border-transparent text-gray-400'
            } ${opt.color}`}
          >
            {opt.label}
          </button>
        ))}
      </div>
    </div>
  );
}