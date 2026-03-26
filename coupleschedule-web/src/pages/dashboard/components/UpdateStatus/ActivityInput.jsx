export function ActivityInput({ value, onChange }) {
    return (
      <div>
        <label className="text-xs text-gray-400 mb-3 block italic">
          O que você está fazendo?
        </label>
        <input 
          type="text" 
          value={value} 
          onChange={(e) => onChange(e.target.value)}
          className="w-full bg-[#F9F9F9] border-none rounded-2xl px-6 py-4 text-lg outline-none focus:ring-1 focus:ring-gray-100 transition-all"
          placeholder="Desenvolvendo a API..."
        />
      </div>
    );
  }