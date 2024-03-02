/** @type {import('tailwindcss').Config} */
module.exports = {
  mode:'jit',
  purge:['./src/**/*.{js,ts,jsx,tsx}'],
  content: ["./src/**/*.{html,js}"],
  theme: {
    extend: {},
  },
  plugins: [],
}

