import fs from 'fs/promises'
import fsSync from 'fs'
import path from 'path'
import axios from 'axios'

(async () => {
    try {
        if (!process.env.AOC_TOKEN) {
            throw new Error('Missing AOC token!')
        }

        const token = process.env.AOC_TOKEN
        const now = new Date()
        let year = now.getFullYear()
        let day = now.getDate()

        if (process.argv.length === 4) {
            year = parseInt(process.argv[2])
            day = parseInt(process.argv[3])
        }

        console.log(`🔍 Finding input for puzzle y${year} d${day}..`)
        const url = `https://adventofcode.com/${year}/day/${day}/input`

        var response = await axios.get(url, {
            headers: {
                Cookie: `session=${token};`
            },
            responseType: 'text'
        })

        if (response.status !== 200) {
            throw new Error(`Could not download input! Status: ${response.status}, body: ${response.data || 'n/a'}`)
        }

        const input = response.data.toString()
        console.log(`✅ Downloaded input (${input.length}ch) in ${new Date().getTime()-now.getTime()}ms`)

        const templateType = determineTemplateType(input)
        console.log(`✅ Determined template type '${templateType}'`)

        console.log('🔍 Loading templates..')
        const { runnerTemplate, solverTemplate } = await loadTemplates(templateType)
        if (!runnerTemplate || runnerTemplate.length === 0 || !solverTemplate || solverTemplate.length === 0) {
            throw new Error('Could not find template files!')
        }
        console.log('✅ Loaded templates!')

        const fullDay = day.toString().padStart(2, '0')
        const solutionPath = path.join(__dirname, `../${year}`)
        const solverPath = path.join(solutionPath, './AOC.Solver', `./Day${fullDay}.cs`)
        const runnerPath = path.join(solutionPath, './AOC.Runner', `./Day${fullDay}Tests.cs`)
        const inputPath = path.join(solutionPath, './AOC.Runner', `./Day${fullDay}.input`)

        if ([solverPath, runnerPath, inputPath].some(path => fsSync.existsSync(path))) {
            throw new Error('Destination files already exists!')
        }

        await Promise.all([
            fs.writeFile(inputPath, input),
            fs.writeFile(runnerPath, runnerTemplate.replace(/\{\{day\}\}/g, fullDay)),
            fs.writeFile(solverPath, solverTemplate.replace(/\{\{day\}\}/g, fullDay)),
        ])
        console.log('✏️ Wrote templates to solution!')
    } catch (e) {
        console.error('❌ Error occured during program execution:', (e as Error).message)
    }
})();

function determineTemplateType(input: string): string {
    const lines = input.split('\n').filter(line => line && line.length > 0)

    if (lines.length === 1) {
        const line = lines[0]
        if (/^-?\d+$/.test(line)) {
            return 'single-line-integer'
        }
        if (/^-?\d+(,-?\d+)+$/.test(line)) {
            return 'single-line-comma-separated-integers'
        }
        if (/^-?\d+(\t-?\d+)+$/.test(line)) {
            return 'single-line-tab-separated-integers'
        }
        if (/^\w+(,\w+)+$/.test(line)) {
            return 'single-line-comma-separated-strings'
        }

        return 'single-line-string'
    }

    if (lines.every(line => /^-?\d+$/.test(line))) {
        return 'newline-separated-integers'
    }

    return 'default'
}

async function loadTemplates(templateType: string): Promise<{runnerTemplate: string, solverTemplate: string}> {
    var solverTemplate = await fs.readFile(path.join(__dirname, `./templates/${templateType}/Solver.cs.template`), { encoding: 'utf8' })
    var runnerTemplate = await fs.readFile(path.join(__dirname, `./templates/${templateType}/Runner.cs.template`), { encoding: 'utf8' })
    return { runnerTemplate, solverTemplate };
}
